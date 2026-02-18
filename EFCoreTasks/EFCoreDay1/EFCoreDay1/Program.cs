using System.Text.RegularExpressions;
using EFCoreDay1.Data;
using EFCoreDay1.Entities;
using EFCoreDay1.Repository;
using EFWithRelationships.Data;



// Helper Method and Input functions ..
static void  ForMemoryAllocation_Validation<T>(ref T? Num, string msg)  where T : IParsable<T>
{
    while (true)
    {
        string? userInput;
        Console.WriteLine($"{msg} ");
        userInput = Console.ReadLine();
        if (T.TryParse(userInput, null, out Num))
        break; 
        Console.WriteLine("Provide appropriate input");
    }
}


var FetchInputForAddStudent = () =>
{
    Student student = new Student();
    Console.WriteLine("Enter Student Name");
    student.Name = Console.ReadLine() ?? "TestUser";

    Console.WriteLine("Enter Student Email");
    string Email = Console.ReadLine() ?? "test123@gmail.com";

   
    Console.WriteLine();

    Regex emailValidatore = new Regex(@"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$");

    while(!emailValidatore.IsMatch(Email))
    {
        Console.WriteLine("Enter valid Format of Email..");
        Email=Console.ReadLine() ?? "test123@gmail.com";
        Console.WriteLine();
    }

    student.Email = Email;

    student.Created = DateTime.Now;

    return student;
};

var FetchInputForAddCourse = () =>
{
    Course course = new Course();
    Console.WriteLine("Enter Course Title: ");
    course.Title = Console.ReadLine() ?? "TestCourse";

    double Fees=1500;
    ForMemoryAllocation_Validation(ref Fees, "Enter Fees for Course: ");
    if(Fees>0) course.Fees = Fees;
    else course.Fees = 1500;

    int DurationInMonths = 6;
    ForMemoryAllocation_Validation(ref DurationInMonths, "Enter Duration In Months: ");
    if (DurationInMonths > 0) course.DurationInMonths = DurationInMonths;
    else course.DurationInMonths=6;

    return course;
};

var FetchInputForAddTrainer = () =>
{
    Trainer trainer = new Trainer();
    Console.WriteLine("Enter Trainer Name");
    trainer.Name = Console.ReadLine() ?? "TestTrainer";
    trainer.Name.Trim();

    int ExperienceYears = 5;
    ForMemoryAllocation_Validation(ref ExperienceYears, "Enter Trainer ExperienceYears");
    if (ExperienceYears > 0)
    {
        trainer.ExperienceYears = ExperienceYears;
    }
    else
    {
        trainer.ExperienceYears = 1;
    }
        return trainer;
};
 
var FetchInputForGettingCourseId = (List<Course> courses) =>
{
    int Id = 1;
    Console.WriteLine("List of Available course...");
    Console.WriteLine("============================================");
    foreach (Course course in courses)
    {
        Console.WriteLine($"Course Title : {course.Title} , Course Id : {course.Id}");
    }
    Console.WriteLine("============================================");
    ForMemoryAllocation_Validation(ref Id, "Enter Id");
    return Id;
};

var FetchInputForGettingTrainerId = (List<Trainer> trainers) =>
{
    int Id = 1;
    Console.WriteLine("============================================");
    foreach (Trainer trainer in trainers)
    {
        Console.WriteLine($"Trainer Name :{trainer.Name} , Trainer Id : {trainer.Id}");
    }
    Console.WriteLine("============================================");
    ForMemoryAllocation_Validation(ref Id, "Enter Id");
    return Id;
};




// For selecting Desired Courses for Student
var FetchAndValidateInputForCourseListFromEnrolledStudent = (Course[] listOfCourses, Student student) =>
{
    int flag = 0;
    while (flag == 0)
    {
        Console.WriteLine("\nSelect 1,2.. accordingly for Enrolling student into desired course (please write 1,2,3 this format)");
        Console.WriteLine("\nList Of Course--->");
        Console.WriteLine("============================");
        foreach (Course course in listOfCourses)
        {
            Console.WriteLine("Course Title is : " + course.Title);
        }
        Console.WriteLine("============================");
        var inputlist = Console.ReadLine();
        string[]? list = inputlist?.Trim().Split(',');
        if (list == null && list?.Length == 0)
        {
            Console.WriteLine("\nInput is not acceptable\n");
        }
        else
        {

            int i = 0;
            while (i < list?.Length)
            {
                int idx = 0;
                idx = int.Parse(list[i]);
                Console.WriteLine("\n============================================");
                if (idx > 0 && idx <= listOfCourses.Count())
                {
                    int idxmain = idx - 1;
                    student.Courses.Add(listOfCourses[idxmain]);
                    Console.WriteLine(idxmain + 1 + " course is " + listOfCourses[idxmain].Title + " Course Enrolled Succsessfully..");
                    i++;
                }
                else
                {
                    Console.WriteLine("Enter valid choice");
                    flag = 1;
                    break;
                }
                Console.WriteLine("============================================\n");

            }
            if (flag == 0) break;
        }

    }
    
};

// For add student to the course's student list(Two way linking)
var AddStudentInStudentListOfCourse = (Student student) =>
{
    var list_Of_Course_In_which_Studentnrolled = student.Courses;
    foreach (var item in list_Of_Course_In_which_Studentnrolled)
    {
        item.Students.Add(student);
    }
};

// For Creating a Batch provide Options to the User for Trainer and Course 
var FetchInputForCreateBatch = (List<Trainer> listOfTrainer,List<Course> listOfCourse) =>
{
    Batch batch = new Batch();
    int Month = 1;
    int Day = 1;
    int Year = 1;

    ForMemoryAllocation_Validation(ref Month, "Enter Batch start Month");
    ForMemoryAllocation_Validation(ref Day, "Enter Batch start Day of Month");
    ForMemoryAllocation_Validation(ref Year, "Enter Batch start Year");

    DateTime startDate = new DateTime(Year,Month,Day);
    batch.StartDate = startDate;

    int choice = 1;
   
    int tag = 1;
    while (tag != 0)
    {
        foreach (Trainer trainer in listOfTrainer)
        {
            Console.WriteLine($"Name of the Trainer is : {trainer.Name}, Experience : {trainer.ExperienceYears}");
        }
        ForMemoryAllocation_Validation(ref choice, "\nEnter 1 or 2 or 3.. for Select a Trainer for Batch..");
        if (choice > 0 && listOfTrainer.Count() >=choice)
        {
            batch.TrainerId = listOfTrainer.ToArray()[choice - 1].Id;
            tag = 0;
        }
        else
        {
            Console.WriteLine("Enter valid choice");
        }

    }
    Console.WriteLine("\n============================================================\n");
    tag = 1;
    while (tag != 0) 
    { 
     
        int choice2 = 1;

        foreach (Course course in listOfCourse)
        {
            Console.WriteLine($"Title of the Course is : {course.Title},  Duration : {course.DurationInMonths}");
        }
    
        ForMemoryAllocation_Validation(ref choice2, "\nEnter 1 or 2 or 3.. for Select a Course for Batch..");
        if (choice2 > 0 && listOfCourse.Count() >=choice2)
        {
            batch.CourseId = listOfCourse.ToArray()[choice2 - 1].Id;
            tag = 0;
        }
        else
        {
            Console.WriteLine("Enter valid choice");
        }

    }
    return batch;
};

// Select Student for Enrolling into the Course..
var FetchStudent = (List<Student> listOfStudents) =>
{
    Student?student = new Student();
    if(listOfStudents.Count() > 0)
    {
        int Id = 0;
        while (true)
        {
            foreach (var std in listOfStudents)
            {
                Console.WriteLine($"Name of the Student is : {std.Name} and Id is :{std.Id}");
            }
            ForMemoryAllocation_Validation(ref Id, "\nEnter id of Student for Enrolling him/her to the course..\n");
            if (Id > 0 && Id <= listOfStudents.Max(x => x.Id))
            {
                student = listOfStudents.Where(x => x.Id == Id).FirstOrDefault();
                break;
            }
            else
            {
                Console.WriteLine("Id is invalid");
            }
        }
    }
    return student;
};




// Print Functions
var PrintCourse = (Course course) =>
{
    Console.WriteLine("Course Ttitle is : "+course.Title);
    Console.WriteLine("Course Fees is : " + course.Fees);
    Console.WriteLine("Course Duration in Months is : " + course.DurationInMonths);
    Console.WriteLine("============================================");
    foreach (var item in course.Students)
    {
        Console.WriteLine($"Student Name is : {item.Name} and Student Email is : {item.Email}");
    }
    foreach (var item in course.Batches)
    {
        Console.WriteLine($"Batch StartDate is : {item.Id}  Batch id is : {item.Id}");
    }
    Console.WriteLine("============================================");

};

var PrintTrainer = (Trainer trainer) =>
{
    Console.WriteLine("=========================================================="); 
    Console.WriteLine("Trainer Name is :"+trainer.Name);
    Console.WriteLine("Year of Experience is :"+trainer.ExperienceYears);
    if(trainer.Batches.Count()==0) { Console.WriteLine("No Records Found"); }
    foreach (var item in trainer.Batches)
    {
        Console.WriteLine($"Batch start Date is : {item.StartDate}");
        Console.WriteLine($"Course Id is : {item.Course.Title}");
        Console.WriteLine($"Course Fees is : {item.Course.Fees}");
        Console.WriteLine($"Course Months is : {item.Course.DurationInMonths}");
    }
    Console.WriteLine("==========================================================");

};






// Controller ..
var AddStudentController =  () =>
{
    using (AppDbContext appDbContext = new AppDbContext())
    {
        StudentRepository studentRepository = new StudentRepository(appDbContext);
        Student newStudent = FetchInputForAddStudent();
       studentRepository.AddStudent(newStudent);
        if (newStudent != null)
            Console.WriteLine("\nStudent Added Successfully...\n");
        else
            Console.WriteLine("\nOperation Failed , Try again..\n");
    }
   
};

var AddCouseController = () =>
{
    using (AppDbContext appDbContext = new AppDbContext())
    {
        CourseRepository courseRepository = new CourseRepository(appDbContext);
        Course newCourse = FetchInputForAddCourse();
        courseRepository.AddCourse(newCourse);
        if (newCourse != null)
            Console.WriteLine("\nCourse Added Successfully...\n");
        else
            Console.WriteLine("\nOperation Failed , Try again..\n");
    }
};

var ShowStudentsController = () =>
{
    using (AppDbContext appDbContext = new AppDbContext())
    {
        StudentRepository studentRepository = new StudentRepository(appDbContext);
        List<Student> ListOfStudent = studentRepository.GetALLStudents();
        if (ListOfStudent.Count == 0)
        {
            Console.WriteLine("Empty Record");
            return;
        }
        foreach (var item in ListOfStudent)
        {
            Console.WriteLine($" Name = {item.Name} Email = {item.Email}  CreatedAt={item.Created}\n");
        }
    }

};

var ShowCourseController = () =>
{
    using (AppDbContext appDbContext = new AppDbContext())
    {
        CourseRepository courseRepository = new CourseRepository(appDbContext);
        List<Course> ListOfCourse = courseRepository.GetALLCourses();
        if (ListOfCourse.Count == 0)
        {
            Console.WriteLine("Empty Record");
            return;
        }
        foreach (var item in ListOfCourse)
        {
            Console.WriteLine($" Title = {item.Title} Fees = {item.Fees}  Duration In Months ={item.DurationInMonths}\n");
        }
    }

};

var EnrolledStudentController = () =>
{
    using (AppDbContext appDbContext = new AppDbContext())
    {
        StudentRepository studentRepository = new StudentRepository(appDbContext);
        Student CurrentStudent = FetchStudent(studentRepository.GetALLStudents());

        CourseRepository courseRepository = new CourseRepository(appDbContext);
        List<Course> listOfCourses = courseRepository.GetALLCourses().ToList();
        
        FetchAndValidateInputForCourseListFromEnrolledStudent(listOfCourses.ToArray(), CurrentStudent);
        
        AddStudentInStudentListOfCourse( CurrentStudent);
        
        appDbContext.SaveChanges();
    }
};

var AddTrainerController = () =>
{
    using(AppDbContext appDbContext = new AppDbContext())
    {
        TrainerRepository trainerRepository = new TrainerRepository(appDbContext);
        Trainer newTrainer = FetchInputForAddTrainer();
        trainerRepository.AddTrainer(newTrainer);
        if (newTrainer != null)
            Console.WriteLine("\nTrainer Added Successfully...\n");
        else
            Console.WriteLine("\nOperation Failed , Try again..\n");
    }
};

var CreateBatchController = () =>
{
    using(AppDbContext appDbContext = new AppDbContext())
    {
        BatchRepository batchRepository = new BatchRepository(appDbContext);
        CourseRepository courseRepository = new CourseRepository(appDbContext);
        TrainerRepository trainerRepository = new TrainerRepository(appDbContext);
        Batch newBatch = FetchInputForCreateBatch(trainerRepository.GetALLTrainers().ToList(), courseRepository.GetALLCourses().ToList());
        Trainer?trainer = trainerRepository.GetTrainer(newBatch.TrainerId);
        Course?course = courseRepository.GetCourse(newBatch.CourseId);

        trainer?.Batches.Add(newBatch);
        course?.Batches.Add(newBatch);

        appDbContext.SaveChanges();
        if (newBatch != null)
            Console.WriteLine("\nBatch Created Successfully...\n");
        else
            Console.WriteLine("\nOperation Failed , Try again..\n");
    }

};

var ShowCourseWithStudentController=() =>{

   using(AppDbContext appDbContext = new AppDbContext())
    {
        CourseRepository courseRepository = new CourseRepository(appDbContext);
        List<Course> courses = courseRepository.GetALLCourses();
        int courseId =FetchInputForGettingCourseId(courses.ToList());
         Course?course=courseRepository.GetCourse(courseId);
        if (course != null)
            PrintCourse(course);
        else
            Console.WriteLine("\nCourse Is Not Found\n");
    }
};

var ShowTrainerWithBatchesController = () =>
{
    using (AppDbContext appDbContext = new AppDbContext())
    {
        TrainerRepository trainerRepository = new TrainerRepository(appDbContext);
        List<Trainer> trainers = trainerRepository.GetALLTrainers();
        int trainerId = FetchInputForGettingTrainerId(trainers.ToList());
        Trainer? trainer = trainerRepository.GetTrainer(trainerId);
        if (trainer != null)
            PrintTrainer(trainer);
        else
            Console.WriteLine("\nTrainer Is Not Found\n");
    }
};



int value = 1;

while (value != 10)
{
    Console.WriteLine("\nEnter 1 for Add New Student");
    Console.WriteLine("Enter 2 for Add New Course");
    Console.WriteLine("Enter 3 for Show All Students ");
    Console.WriteLine("Enter 4 for show All Courses");
    Console.WriteLine("Enter 5 for Enrolle Student");
    Console.WriteLine("Enter 6 for Add Trainer");
    Console.WriteLine("Enter 7 for Create Batch");
    Console.WriteLine("Enter 8 for show Course with Students");
    Console.WriteLine("Enter 9 for show Trainer with Batches");
    Console.WriteLine("Enter 10 for Exite");
    ForMemoryAllocation_Validation(ref value, "Enter choice");
    switch (value)
    {
        case 1:
            {
                AddStudentController();
                break;
            }
        case 2:
            {
                AddCouseController();
                break;
            }
        case 3:
            {
                ShowStudentsController();
                break;
            }
        case 4:
            {
                ShowCourseController();
                break;
            }
        case 5:
            {
                
                EnrolledStudentController();
                break;
            }
        case 6:
            {
                AddTrainerController();
                break;
            }
        case 7:
            {
                CreateBatchController();
                break;
            }
        case 8:
            {
                ShowCourseWithStudentController();
                break;
            }
        case 9:
            {
                ShowTrainerWithBatchesController();
                break;
            }
        case 10:
            {
                Console.WriteLine("Thank you for review..");
                break;
            }
        default:
            {
                Console.WriteLine("\nEnter valid choice\n");
                break;
            }
    }


    
}



