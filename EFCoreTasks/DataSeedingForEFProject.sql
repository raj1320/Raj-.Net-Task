select * from Students;
select * from Courses;
select * from CourseStudent;
select * from Trainers;
select * from Batches;


Insert Into Trainers(Name,ExperienceYears)
Values('Manoj Kumar',6),
('Pooja Sharma',4);


Insert Into Courses(Title,Fees,DurationInMonths)
Values('.Net Development',15000,6),
('Fullstack Development',20000,8);


Insert Into Students(Name,Email,Created)
Values('Raj Rana','raj123@gmail.com',GETUTCDATE()),
('Ravi Vadher','ravi123@gmail.com',GETUTCDATE()),
('Rakesh paramr','rakesh123@gmail.com',GETUTCDATE());