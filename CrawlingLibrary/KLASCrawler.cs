using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Threading;
using System.Net.Configuration;
using OpenQA.Selenium.Support.UI;
using CrawlingLibrary;
using EntityLibrary;
using System.Net;

namespace CrawlingLibrary
{ 

    // crawls KLAS web page and lecture datas that user takes

    public class KLASCrawler
    {
        public List<Lecture> lectures = new List<Lecture>();
        
        List<string> lectureNames = new List<string>();

        int lectureNum;

        List<Schedule> klasSchedules = new List<Schedule>(); // klas 관련 Schedules

        public static string id;
        public static string pwd;

        public string username;

        public static ChromeDriverService chromeDriverService;
        public static ChromeDriver chromeDriver;

        public event EventHandler<EventArgs> loginSuccessEvent;

        public event EventHandler<EventArgs> crawlingEvent;

        public KLASCrawler() {}

        public int getLectureNum()
        {
            return lectureNum;
        }

        public string getUsername()
        {
            return username;
        }
        

        public List<Schedule> getKLASSchedules() {  return  klasSchedules; }


        public void setSchedules()
        {
            foreach(Lecture lecture in lectures)
            {
                // 모든 스케줄은 마감일 당일만 진행하도록 세팅 => 마감일 표시가 더 중요하므로..
                
                // OnlineLecture Schedule
                foreach(OnlineLecture onlineLecture in lecture.getOnlineLecture())
                {
                    string title = "온라인 강의 수강";
                    string content = lecture.getName() + "\n온라인 강의 수강";

                    DateTime startTime = Convert.ToDateTime(onlineLecture.getDueDate());

                    string endTimeLine = onlineLecture.getDueDate() + " 23:59:59";
                    DateTime endTime = DateTime.ParseExact(endTimeLine, "yyyy-MM-dd HH:mm:ss", null);

                    Schedule schedule = new Schedule("KLAS",title,content,startTime,endTime);
                    klasSchedules.Add(schedule);
                }

                // Assignment Schedule
                foreach (Assignment assignment in lecture.getAssignment())
                {
                    string title = "과제 제출";
                    string content = lecture.getName()  + "\n과제 제출";

                    DateTime startTime = Convert.ToDateTime(assignment.getDueDate());

                    string endTimeLine = assignment.getDueDate() + " 23:59:59";
                    DateTime endTime = DateTime.ParseExact(endTimeLine, "yyyy-MM-dd HH:mm:ss", null);


                    Schedule schedule = new Schedule("KLAS",title,content,startTime,endTime);
                    klasSchedules.Add(schedule);
                }



                // Quiz Schedule
                foreach (Quiz quiz in lecture.getQuiz())
                {
                    string title = "퀴즈 응시";
                    string content = lecture.getName() + "\n퀴즈 응시";

                    DateTime startTime = Convert.ToDateTime(quiz.getDueDate());

                    string endTimeLine = quiz.getDueDate() + " 23:59:59";
                    DateTime endTime = DateTime.ParseExact(endTimeLine, "yyyy-MM-dd HH:mm:ss", null);


                    Schedule schedule = new Schedule("KLAS",title,content,startTime,endTime) ;
                    klasSchedules.Add(schedule);
                }



                // Team Project Schedule
                foreach (TeamProject teamProject in lecture.getTeamProject())
                {
                    string title = "팀 프로젝트 진행";
                    string content = lecture.getName() + "\n팀 프로젝트 진행";

                    DateTime startTime = Convert.ToDateTime(teamProject.getDueDate());

                    string endTimeLine = teamProject.getDueDate() + " 23:59:59";
                    DateTime endTime = DateTime.ParseExact(endTimeLine, "yyyy-MM-dd HH:mm:ss", null);

                    Schedule schedule = new Schedule("KLAS",title,content,startTime,endTime);
                    klasSchedules.Add(schedule);
                }

            }


        }



        public void initDriver()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--headless");
            //options.AddArgument("--disable-gpu");

            chromeDriverService = ChromeDriverService.CreateDefaultService();
            // hide chromedriver.exe
            chromeDriverService.HideCommandPromptWindow = true;
            chromeDriver = new ChromeDriver(chromeDriverService, options);

            chromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);

        }


        // do all of things including login, crawling all datas and etc.. 
        public CrawlingStatus.Status doWork(string id, string pwd)
        {
            
            KLASCrawler.id = id;
            KLASCrawler.pwd = pwd;

            try
            {
                initDriver();

                CrawlingStatus.Status loginStatus = loginKLAS(id, pwd);
                if (loginStatus == CrawlingStatus.Status.LoginFailure)
                {
                    garbageResources();
                    return loginStatus;
                }
                else // 로그인 성공이면 로그인 폼에서 크롤링 작업을 시작한다는 메시지를 띄우도록
                    loginSuccessEvent.Invoke(this,new EventArgs());                   


                CrawlingStatus.Status crawlBasicStatus = crawlBasicLectureDatas();

                CrawlingStatus.Status crawlMainStatus = crawlMainLectureDatas();

                // klas 스케줄 설정 
                setSchedules();

                if (crawlBasicStatus == CrawlingStatus.Status.CrawlingError || crawlMainStatus == CrawlingStatus.Status.CrawlingError)
                {
                    garbageResources();
                    return CrawlingStatus.Status.CrawlingError;
                }


                garbageResources();
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error while Setting chromeDriverService and chromeDriver " + ex);
                
            }


            return CrawlingStatus.Status.AllSuccess;
        }


        public void garbageResources()
        {
            try 
            {
              chromeDriver.Quit();

            }
            catch (Exception e)
            {

            }
        }


        public static CrawlingStatus.Status loginKLAS(string id, string pwd)
        {

            try
            {
                chromeDriver.Navigate().GoToUrl("https://klas.kw.ac.kr/");

                // send id and pwd data 
                var element = chromeDriver.FindElement(By.XPath("//*[@id=\"loginId\"]"));
                element.SendKeys(id);

                element = chromeDriver.FindElement(By.XPath("//*[@id=\"loginPwd\"]"));
                element.SendKeys(pwd);

                // automatically click login button 
                element = chromeDriver.FindElement(By.XPath("/html/body/div[1]/div/div/div[2]/form/div[2]/button"));
                element.Click();
                Thread.Sleep(1000);

                // klas 로그인 실패 시, 오류 알림이 뜸.. 
                if (isElementExists(chromeDriver, By.XPath("//*[@id=\"ax5-dialog-27\"]/div[2]/div[1]")) == true)
                    return CrawlingStatus.Status.LoginFailure;
                
            } catch(Exception ex)
            {
                //Console.WriteLine(ex.Message + "Error while loginKLAS process.. " + ex );
                return CrawlingStatus.Status.LoginFailure;
            }

            return CrawlingStatus.Status.LoginSuccess;
        }


        public CrawlingStatus.Status crawlBasicLectureDatas()
        {

            try
            {
                // crawl userName 
                var userNameData = chromeDriver.FindElement(By.CssSelector("body > header > div.navbar.navbar-dark.bg-top > div > div.col-md-6.navtxt > a:nth-child(1)"));
                username = userNameData.Text.ToString().Split('(')[0];

                // crawl lecture name,professor,time and room from KLAS main page
                for (int i = 1; ; i++)
                {
                    string cssSelector = "#appModule > div > div:nth-child(1) > div:nth-child(2) > ul > li:nth-child(" + i + ") > div.left";

                    // exit condition
                    if (isElementExists(chromeDriver, By.CssSelector(cssSelector)) == false) break;
                    var lectureData = chromeDriver.FindElement(By.CssSelector(cssSelector));

                    //Console.WriteLine(lectureData.Text);

                    string[] lectureParsed = lectureData.Text.ToString().Split('\n');

                    string lectureName = lectureParsed[0].Split(' ')[0];
                    lectureNames.Add(lectureName);
                    string[] lectureInfo = lectureParsed[1].Split(' ');

                    string professorName = lectureInfo[0];

                    string[] lectureTime = new string[2];
                    string[] lectureRoom = new string[2];

                    lectureTime[0] = lectureInfo[2] + " " + lectureInfo[3].Split('/')[0];
                    //Console.WriteLine(lectureTime[0]);

                    lectureRoom[0] = lectureInfo[3].Split('/')[1];
                    //Console.WriteLine(lectureRoom[0]);

                    // lecture for two days in a week
                    if (lectureInfo.Length == 6)
                    {
                        lectureTime[1] = lectureInfo[4] + " " + lectureInfo[5].Split('/')[0];
                        // Console.WriteLine(lectureTime[1]);

                        lectureRoom[1] = lectureInfo[5].Split('/')[1];
                        // Console.WriteLine(lectureRoom[1]);

                    }

                    Lecture lecture = new Lecture(lectureName, professorName, lectureTime, lectureRoom);
                    lectures.Add(lecture);
                }


                lectureNum = lectures.Count;

            }
            catch (Exception e)
            {
                //Console.WriteLine(e.Message + "Error while crawling basic lectureData process.." + e);
                return CrawlingStatus.Status.CrawlingError;
            }

            return CrawlingStatus.Status.CrawlingSuccess;
        }



        public void printLectureDatas(List<Lecture> lectures)
        {
            foreach (var lecture in lectures)
                lecture.printLectureDatas();
        }


        public class ChromeDriverFactory
        {
            public ChromeDriver Create(int i)
            {

                ChromeDriverService chromeDriverService;
                ChromeDriver chromeDriver;

                ChromeOptions options = new ChromeOptions();
                options.AddArgument("--headless");
                //options.AddArgument("--disable-gpu");

                chromeDriverService = ChromeDriverService.CreateDefaultService();
                chromeDriverService.HideCommandPromptWindow = true;
                chromeDriver = new ChromeDriver(chromeDriverService, options);
                chromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);

                loginKLAS(id,pwd);
                
                // 과목명 옵션별로 선택하기 버튼 
                string optionXpath = "//*[@id=\"appModule\"]/div/div[1]/div[2]/ul/li[" + i + "]/div[1]";

                //*[@id="appModule"]/div/div[1]/div[2]/ul/li[1]/div[1]
                //*[@id="appModule"]/div/div[1]/div[2]/ul/li[2]/div[1]

                // 각 과목 선택 후 클릭 
                var element = chromeDriver.FindElement(By.XPath(optionXpath));
                element.Click();
                Thread.Sleep(300);

                return chromeDriver; 
            }

        }


        // crawl notices,online lectures, assignments, quiz, team projects and online tests.. 
        private CrawlingStatus.Status crawlMainLectureDatas()
        {
          //  var factory = new ChromeDriverFactory();

            try
            {
                // 처음에는 메인페이지에서 첫 과목의 종합페이지로 진입
                var element = chromeDriver.FindElement(By.XPath("//*[@id=\"appModule\"]/div/div[1]/div[2]/ul/li[1]/div[1]"));
                element.Click();
                Thread.Sleep(500);

                // index starts from 1 => for each lecture!
                for (int i = 1; i <= lectureNum; i++)
                {

                    // 과목명 옵션별로 선택하기 버튼 
                    string optionXpath = "//*[@id=\"appSelectSubj\"]/div[2]/div/div[2]/select/option[" + i + "]";

                    // 각 과목 선택 후 클릭 
                    element = chromeDriver.FindElement(By.XPath(optionXpath));
                    element.Click();
                    Thread.Sleep(500);

                    // time to crawl all datas..
                    List<Notice> notices = crawlNoticeData();
                    moveToOverallPage();

                    List<OnlineLecture> onlineLectures = crawlOnlineLectureData();

                    List<Assignment> assignments = crawlAssignmentData();

                    List<Quiz> quizs = crawlQuizData();

                    List<TeamProject> teamProjects = crawlTeamProjectData();


                    lectures[i - 1].setNotice(notices);
                    lectures[i - 1].setOnlineLecture(onlineLectures);
                    lectures[i - 1].setAssignment(assignments);
                    lectures[i - 1].setQuiz(quizs);
                    lectures[i - 1].setTeamProject(teamProjects);

                    crawlingEvent.Invoke(this, new EventArgs());
                }
            }
            catch (Exception e)
            {
                //Console.WriteLine(e.ToString());
                //Console.WriteLine("Error while crawling main lectureDatas process..");
                return CrawlingStatus.Status.CrawlingError;
            }

            return CrawlingStatus.Status.CrawlingSuccess;
        }





        // move to main page of each course
        public static void moveToOverallPage()
        {
            try
            {   //*[@id="appHeaderSubj"]/div/div/div[1]/span[1]
                //WaitForVisible(chromeDriver, By.XPath("//*[@id=\"appHeaderSubj\"]/div/div/div[1]/span[1]"));
                var element = chromeDriver.FindElement(By.XPath("//*[@id=\"appHeaderSubj\"]/div/div/div[1]/span[1]"));
                element.Click();
                Thread.Sleep(500);

            }
            catch (Exception e) 
            {
                Console.WriteLine("Error while moving to Overall Page " + e);
            }

        }



        // --------------------------------------------  Notice Part  -------------------------------------------------



        // move to Notice Page 
        private void moveToNoticePage()
        {
            //WaitForVisible(chromeDriver, By.XPath("//*[@id=\"appModule\"]/div[1]/div[1]/div/div[1]/a"));
            var element = chromeDriver.FindElement(By.XPath("//*[@id=\"appModule\"]/div[1]/div[1]/div/div[1]/a"));
            element.Click();
            Thread.Sleep(300);
        }


        private List<Notice> crawlNoticeData()
        {
            moveToNoticePage();
            List<Notice> notices = new List<Notice>();
  
            try
            {
               // WaitForVisible(chromeDriver, By.XPath("//*[@id=\"appModule\"]/table/tbody/tr/td"));
                // if notice doesn't exist, then testString is "글이 없습니다."
                string testString = chromeDriver.FindElement(By.XPath("//*[@id=\"appModule\"]/table/tbody/tr/td")).Text.ToString();

                if (testString.Contains("글이 없습니다"))
                {
                    return notices;
                }
                else
                {   
                    // if notice exists
                    //Console.WriteLine("Notice exists");

                    var noticeTable = chromeDriver.FindElement(By.XPath("//*[@id=\"appModule\"]/table/tbody"));

                    string[] rawNotices = noticeTable.Text.Split('\n');
                    foreach (string notice in rawNotices)
                    {
                        string[] reverseNotice = notice.Split(' ').Reverse().ToArray();

                        string viewCount = reverseNotice[0];
                        string date = reverseNotice[1];
                        string author = reverseNotice[2];

                        string[] titleWords = reverseNotice.Skip(3).Reverse().ToArray();

                        // if titleWords[0] is number, should remove it!
                        if (int.TryParse(titleWords[0], out int n))
                            titleWords = titleWords.Skip(1).ToArray();

                        string title = string.Join(" ", titleWords);
                        string description = "";

                        Notice unitNotice = new Notice(title, description, author, date, viewCount);
                        notices.Add(unitNotice);
                    }


                }
            }
            catch( Exception e)
            {
                Console.WriteLine("Error while crawlNoticePage() " + e);
            }
            
            return notices;
        }



        // -----------------------------------------   Quiz Part  -----------------------------------------------


        // move to Quiz page (해당 강의 종합 페이지 -> 퀴즈 버튼 클릭 후 이동)
        private void moveToQuizPage()
        {
            var element = chromeDriver.FindElement(By.XPath("//*[@id=\"appModule\"]/div[1]/div[2]/div/div[2]/div/div[2]/ul/li[3]/a"));
            element.Click();
            Thread.Sleep(300);
        }

        private List<Quiz> crawlQuizData()
        {
            List<Quiz> quizs = new List<Quiz>();

            try
            {

                // 강의 페이지에서 퀴즈 "n/m" 데이터 parsing
                string testString = chromeDriver.FindElement(By.XPath("//*[@id=\"appModule\"]/div[1]/div[2]/div/div[2]/div/div[2]/ul/li[3]/a/span")).Text.ToString();
                testString = testString.Split('/')[1];
                int numQuiz = Int32.Parse(testString);

                if (numQuiz == 0)
                {
                    return quizs;
                }
                else
                {
                    //Console.WriteLine("Quiz exists");
                    moveToQuizPage();
                    
                    // crawl whole quiz table data
                    var quizTable = chromeDriver.FindElement(By.XPath("//*[@id=\"prjctList\"]/tbody"));
                    Console.WriteLine(quizTable.Text);

                    string[] rawQuizs = quizTable.Text.Split('\n');
                    foreach (string rawQuiz in rawQuizs)
                    {
                        // 주, 회, 시험유형, 응시, 응시결과 부분 삭제
                        string[] pureQuizArray = rawQuiz.Split(' ').Skip(3).Reverse().Skip(2).Reverse().ToArray();
                        string pureQuiz = string.Join(" ", pureQuizArray);

                        // 상태 추출 
                        string state = pureQuiz.Split(' ').Reverse().ToArray()[0];
                        
                        // 제출기한 추출
                        string[] deadlinePart = pureQuiz.Split(' ').Reverse().Skip(1).Take(5).Reverse().ToArray();
                        string deadline = string.Join(" ", deadlinePart);
                        
                        // 퀴즈 제목 추출 
                        string[] titlePart = pureQuiz.Split(' ').Reverse().Skip(6).Reverse().ToArray();
                        string title = string.Join(" ", titlePart);
                        
                        Quiz quiz = new Quiz(title, deadline, state);
                        quizs.Add(quiz);
                    }

                    moveToOverallPage();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Error while crawlOnlineLecturePage() " + e);

                moveToOverallPage();
            }

            return quizs;
        }


        // --------------------------------------------  Online Lecture Part  ------------------------------------------------


        // move to Online Lecture Page (해당 강의 종합 페이지 -> 온라인강의 버튼 클릭 후 이동)
        private void moveToOnlineLecturePage()
        {
           // WaitForVisible(chromeDriver, By.XPath("//*[@id=\"appModule\"]/div[1]/div[2]/div/div[2]/div/div[1]/ul/li[1]/a/span"));
              
            var element = chromeDriver.FindElement(By.XPath("//*[@id=\"appModule\"]/div[1]/div[2]/div/div[2]/div/div[1]/ul/li[1]/a"));
            element.Click();
            Thread.Sleep(300);
        }

        // 온라인 강의 정보 Crawling
        private List<OnlineLecture> crawlOnlineLectureData()
        {
            List<OnlineLecture> onlineLectures = new List<OnlineLecture>();

            try
            {
                  
                // 강의 페이지에서 온라인 강의 "n/m" 데이터 parsing
                string testString = chromeDriver.FindElement(By.XPath("//*[@id=\"appModule\"]/div[1]/div[2]/div/div[2]/div/div[1]/ul/li[1]/a/span")).Text.ToString();
                testString = testString.Split('/')[1];
                int numLecture = Int32.Parse(testString);

                if (numLecture == 0)
                {
                    return onlineLectures;
                }
                else
                {
                    //Console.WriteLine("OnlineLecture exists");
                    moveToOnlineLecturePage();
                    
                    // crawl whole quiz table data
                    var onlineLectureTable = chromeDriver.FindElement(By.XPath("//*[@id=\"prjctList\"]/tbody"));
                    
                    string[] fullRawOnlineLectures = onlineLectureTable.Text.Split('\n').ToArray();
                    
                    for (int i = 0; i < fullRawOnlineLectures.Length;)
                    {
                        string fullRawOnlineLecture = fullRawOnlineLectures[i];
                        if (fullRawOnlineLecture.Contains("강의영상"))
                        {
                            // 학습기간 추출 
                            string[] deadlinePart = fullRawOnlineLecture.Split(' ').Reverse().Take(5).Reverse().ToArray();
                            string deadline = string.Join(" ", deadlinePart);

                            // 강의 제목 추출 
                            string[] titlePart = fullRawOnlineLecture.Split(' ').Reverse().Skip(5).ToArray();
                            string title = "";
                            foreach (string subtitle in titlePart)
                            {
                                // 만약 강의 영상 부분이라면, break
                                if (string.Compare(subtitle, "강의영상") == 0) break;
                                title += subtitle;
                                title += " ";
                            }

                            titlePart = title.Split(' ').Reverse().ToArray();
                            title = string.Join(" ", titlePart);

                            // 학습 정도 퍼센트 추출 
                            string percentagePart = fullRawOnlineLectures[i + 2].Split(']')[0];
                            string percentage = percentagePart.Split(',')[1];

                            OnlineLecture onlineLecture = new OnlineLecture(title, deadline, percentage);
                            onlineLectures.Add(onlineLecture);

                            // 강의영상은 3줄씩 구성되어 있음 
                            i += 3;
                            continue;
                        }
                        else // 만약 강의영상이 아니라 과제,퀴즈 등이라면 건너뛰도록 => parsing 결과 2줄씩 구성되어있음 
                        {
                            i += 2;
                            continue;
                        }

                    }


                    moveToOverallPage();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Error while crawlOnlineLecturePage() " + e);
            }

            return onlineLectures;
        }


        // --------------------------------------------  Assignment Part  ------------------------------------------------

        // move to Assignment Page(해당 강의 종합 페이지 -> 과제 버튼 클릭 후 이동)
        private void moveToAssignmentPage()
        {
            var element = chromeDriver.FindElement(By.XPath("//*[@id=\"appModule\"]/div[1]/div[2]/div/div[2]/div/div[2]/ul/li[2]/a"));
            element.Click();
            Thread.Sleep(300);
        }


        // 과제 정보 Crawling 
        private List<Assignment> crawlAssignmentData()
        {
            
            List<Assignment> assignments = new List<Assignment>();

            try
            {
                
                // 강의 페이지에서 과제 "n/m" 데이터 parsing
                string testString = chromeDriver.FindElement(By.XPath("//*[@id=\"appModule\"]/div[1]/div[2]/div/div[2]/div/div[2]/ul/li[2]/a/span")).Text.ToString();
                testString = testString.Split('/')[1];
                int numAssignment = Int32.Parse(testString);

                if (numAssignment == 0)
                {
                     return assignments;
                }
                else
                {
                    //Console.WriteLine("Assignment exists");
                    moveToAssignmentPage();
                    

                    // crawl whole assignment table data
                    var assignmentTable = chromeDriver.FindElement(By.XPath("//*[@id=\"appModule\"]/div/div[3]/table"));

                    string[] fullRawAssignments = assignmentTable.Text.Split('\n').Skip(2).ToArray();
                    
                    List<string> rawAssignments = new List<string>();
                    // extract additional deadline(추가제출기한) 
                    for (int i = 0; i < fullRawAssignments.Length; i += 2)
                    {
                        rawAssignments.Add(fullRawAssignments[i]);
                    }

                    foreach (string rawAssignment in rawAssignments)
                    {

                        // 주, 회, 시험유형, 응시, 응시결과 부분 삭제
                        string[] pureAssignmentArray = rawAssignment.Split(' ').Skip(1).Reverse().Skip(2).Reverse().ToArray();
                        string pureAssignment = string.Join(" ", pureAssignmentArray);


                        // 상태 추출 
                        string state = pureAssignment.Split(' ').Reverse().ToArray()[0];

                        // 제출기한 추출 
                        string[] deadlinePart = pureAssignment.Split(' ').Reverse().Skip(1).Take(5).Reverse().ToArray();
                        string deadline = string.Join(" ", deadlinePart);


                        // 과제 제목 추출
                        string[] titlePart = pureAssignment.Split(' ').Reverse().Skip(6).Reverse().ToArray();
                        string title = string.Join(" ", titlePart);


                        Assignment assignment = new Assignment(title, deadline, state);
                        assignments.Add(assignment);
                    }

                    moveToOverallPage();
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine("Error while crawlOnlineLecturePage() " + e);
            }

            return assignments;
        }



        // --------------------------------------  Team Project Part  ----------------------------------------------


        // move to Team Project Page (해당 강의 종합 페이지 -> 팀프로젝트 버튼 클릭 후 이동)
        private void moveToTeamProjectPage()
        {
            var element = chromeDriver.FindElement(By.XPath("//*[@id=\"appModule\"]/div[1]/div[2]/div/div[2]/div/div[1]/ul/li[2]/a"));
            element.Click();
            Thread.Sleep(300);
        }

        private List<TeamProject> crawlTeamProjectData()
        {
            List<TeamProject> teamProjects = new List<TeamProject>();

            try
            {
                // 강의 페이지에서 팀프로젝트 "n/m" 데이터 parsing
                string testString = chromeDriver.FindElement(By.XPath("//*[@id=\"appModule\"]/div[1]/div[2]/div/div[2]/div/div[1]/ul/li[2]/a/span")).Text.ToString();
                testString = testString.Split('/')[1];
                int numTeamProject = Int32.Parse(testString);

                if (numTeamProject == 0)
                {
                   return teamProjects;
                }
                else
                {
                    //Console.WriteLine("Project exists");
                    moveToTeamProjectPage();
                    
                    // crawl whole assignment table data
                    var teamProjectTable = chromeDriver.FindElement(By.XPath("//*[@id=\"appModule\"]/table"));
                    //Console.WriteLine(teamProjectTable.Text);

                    string[] fullRawTeamProjects = teamProjectTable.Text.Split('\n').Skip(2).ToArray();
                    
                    List<string> rawTeamProjects = new List<string>();
                    for (int i = 0; i < fullRawTeamProjects.Length; i += 2)
                        rawTeamProjects.Add(fullRawTeamProjects[i]);

                    foreach (string rawTeamProject in rawTeamProjects)
                    {
                    
                        // 번호, 조회, 과제공개여부 부분 삭제 
                        string[] pureTeamProjectArray = rawTeamProject.Split(' ').Skip(1).Reverse().Skip(2).Reverse().ToArray();
                        string pureTeamProject = string.Join(" ", pureTeamProjectArray);

                        // 상태 추출 
                        string state = pureTeamProject.Split(' ').Reverse().ToArray()[0];

                        // 제출기한 추출 
                        string[] deadlinePart = pureTeamProject.Split(' ').Reverse().Skip(1).Take(3).Reverse().ToArray();
                        string deadline = string.Join(" ", deadlinePart);

                        // 과제 제목 추출
                        string[] titlePart = pureTeamProject.Split(' ').Reverse().Skip(4).Reverse().ToArray();
                        string title = string.Join(" ", titlePart);

                        TeamProject teamProject = new TeamProject(title, deadline, state);
                        teamProjects.Add(teamProject);
                    }


                    moveToOverallPage();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Error while crawlOnlineLecturePage() " + e);
            }

            return teamProjects;
        }



        // check corresponding element exists 
        private static bool isElementExists(ChromeDriver driver, By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }


        /*private static bool WaitForVisible(IWebDriver driver, By by,string targetName)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
            
            try
            {
                IWebElement element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(by));
                if(element.Text.Contains(targetName))
                {
                    Console.WriteLine(element.Text);
                    return true;
                }
            }
            catch(Exception e)
            {
                return false;
            }

            return false;
        }
*/


    }
}
