Use masterCreate Database JMDROOFWORKS_TASKUse JMDROOFWORKS_TASK

Create Table Job_Cards
( 
JobCardId Int primary key not null,
JobType varchar (50),
DailyRate decimal (10,2),
NumberOfDays int, 
) ;
Create Table Employee
(
EmployeeId varchar (10) not null,
JobCardId int foreign key references Job_Cards(JobCardId),
EmployeeNames varchar (60)
) ;
Create Table Customer
(
JobCardId int foreign key references Job_Cards(JobCardId),
CustomerNames varchar(40),
StreetAdress varchar (50),
City varchar (20),
PostalCode varchar (5)
) ;
Create Table Job_Material
(
JobCardId int foreign key references Job_Cards(JobCardId),
MaterialUsed varchar(200),
) ;
Create Table Invoices
(
JobCardId int foreign key references Job_Cards(JobCardId),
SubTotal money,
Vat money  ,
Total money 
) ;

insert into Job_Cards values
(11000,'Full Conversion',1200.00,7),
(10478,'Semi Conversion',1080.00,2),
(14253,'Floor Boarding' , 900.00, 2),
(11258,'Full Conversion',1200.00,8),
(12058,'Semi Conversion',1080.00,3),
(13697,'Full Conversion',1200.00,7),
(10211,'Full Conversion',1200.00,7),
(10471,'Semi Conversion',1080.00,2),
(13521,'Semi Conversion',1080.00,3),
(10102,'Floor Boarding' , 900.00,2); 
insert into Customer values
(11000,'Tendai Ndoro', '3 Leos Place 457 Church str', 'Pretoria', '0002'), 
(10478, 'Donald Puttingh', '408 Oubos 368 Prinsloo str', 'Pretoria', '0001'),
(14253,'Tracy Sampson', '206 Albertros 269 Stead Avenue', 'Pretoria', '0186'), 
(11258, 'Jacob Smith', '201 Ocerton 269 Debouvlrde Str', 'Pretoria', '0002'),
(12058 ,'Thato Moleto', '11 Luttig Court 289 MALTZAN Str', 'Pretoria', '0001'), 
(13697, 'Dakalo Mudau', '1182 CEBINIA Str', 'Pretoria', '0082'),
(10211,'Sfiso Myeni', '503 Hamilton Gardens 337 Visagie Str', 'Pretoria', '0001'), 
(10471, 'Riccardo Keyl', '10 Silville 614 Jasmyn Str', 'Pretoria', '0184'),
(13521,'Smallboy Mtshali', '307 FEORA East', 'Pretoria-West', '0183'), 
(10102, 'Wilson Jansen', '701 Monticchico Flat 251 Jacob Mare Str', 'Pretoria', '0002');
insert into Employee (EmployeeId, JobCardId, EmployeeNames)  values
('Emp100',11000, 'Albert Malose'), 
('Emp920',11000, 'Chris Byne'), 
('Emp010',11000, 'John Hendriks'), 
('Emp920',10478, 'Chris Byne'), 
('Emp771',14253, 'Smallboy Modipa'), 
('Emp681',11258, 'Stanley Jacobs'), 
('Emp010',11258, 'John Hendriks'),  
('Emp771',11258, 'Smallboy Modipa'),  
('Emp681',12058, 'Stanley Jacobs') ;
insert into Invoices values
(11000,8400.00,1176.00,9576.00), 
(10478,2160.00, 302.40,2462.40),
(14253,1800.00, 252.00,2052.00),
(11258,9600.00,1344.00,1944.00), 
(12058,3240.00, 453.60,3693.60), 
(13697,8400.00,1176.00,9576.00), 
(10211,8400.00,1176.00,9576.00),
(10471,2160.00, 302.40,2462.40), 
(13521,3240.00, 453.60,3693.60), 
(10102,1800.00, 252.00,2052.00);
insert into Job_Material values
(
11000,'- 90 x standard floor boards,'+char(10)+'
- 3 x power points,
- 20 metres packdard electrical wiring,
- Standard stairs pack'), 
(10478,'- 50 x standard floor boards
- 1x power points
- 10 metres standard electrical wiring'), 
(14253,'- 40 x standard floor boards'), 
(11258,'- 80 x standard floor boards
- 3 x power points
- 20 metres standard electrical wiring
- Standard stairs pack'), 
(12058,'- 60 x standard floor boards
- 2 x power points
- 15 metres standard electrical wiring'), 
(13697,'- 80 x standard floor boards
- 4 x power points
- 40 metres standard electrical wiring
- Standard stairs pack'), 
(10211,'- 100 x standard floor boards
- 5 x power points
- 30 metres standard electrical wiring
- Standard stairs pack'), 
(10471,'- 40 x standard floor boards
- 1 x power point
- 8 metres standard electrical wiring'), 
(13521,'- 65 x standard floor boards
- 3 x power points
- 18 metres standard electrical wiring'), 
(10102,'- 70 x standard floor boards');

-- this will selects all the job cards and the employees that have worked on them.
select j.JobCardId, e.EmployeeNames from
Employee e inner join Job_Cards j on
j.JobCardId = e.JobCardId;

--This will select the materials that have been used on job cards of type ‘Full Conversion’.
select j.JobType, jm.MaterialUsed from
Job_Cards j inner join Job_Material jm
on j.JobCardId =jm.JobCardId 
where j.JobType = 'Full Conversion';

--this will select all the job cards that Chris Byne has worked on. 
select j.JobCardId, e.EmployeeNames from
Job_Cards j right join Employee e on
j.JobCardId = e.JobCardId where
e.EmployeeNames = 'Chris Byne'; 

--This will shows all job cards that have taken place in addresses that contain ‘0001’ or ‘0002’.
select j.JobCardId, c.PostalCode, c.streetAdress from
Customer c left join Job_Cards j on
c.JobCardId = j.JobCardId where
c.PostalCode = '0001' or
c.PostalCode ='0002' Order By c.PostalCode asc;

--counts the number of jobsthat have used electrical wiring 
select count(*) as NumOfRows from Job_Material jm 
where jm.MaterialUsed like '%electrical wiring%';

-- this is the output that could be used to prepare an invoice. 
select j.JobType, j.DailyRate,j.NumberOfDays,
j.DailyRate * j.NumberOfDays as totalCost,
(j.DailyRate * j.NumberOfDays) *0.14 as Vat
from Job_Cards j;

--Updating the DailyRate 
UPDATE Job_Cards 
SET DailyRate = 1440.00
WHERE JobType = 'Full Conversion';




