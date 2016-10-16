USE MN_PrivateLibrary;


--MEMBERSHIP TYPE
INSERT INTO Member.MembershipType([MaxBookAmount],[Name],[MonthPlan],[PricePerMonth],[OverdueDayLimit],[OverdueFees]) VALUES (1,'Silver',	3,	20.00,	30, 0.40);
INSERT INTO Member.MembershipType([MaxBookAmount],[Name],[MonthPlan],[PricePerMonth],[OverdueDayLimit],[OverdueFees]) VALUES (2,'Gold',		6,	17.50,	45,	0.30);
INSERT INTO Member.MembershipType([MaxBookAmount],[Name],[MonthPlan],[PricePerMonth],[OverdueDayLimit],[OverdueFees]) VALUES (4,'Platinum',	12,	14,		60,	0.20);

--BOOKS LOCATION
INSERT INTO Book.BooksLocation([Floor], [Shelf]) VALUES (1,	'Storage');
INSERT INTO Book.BooksLocation([Floor], [Shelf]) VALUES (1,	'1A');
INSERT INTO Book.BooksLocation([Floor], [Shelf]) VALUES (1,	'1B');
INSERT INTO Book.BooksLocation([Floor], [Shelf]) VALUES (1,	'1C');
INSERT INTO Book.BooksLocation([Floor], [Shelf]) VALUES (1,	'1D');
INSERT INTO Book.BooksLocation([Floor], [Shelf]) VALUES (1,	'1E');
INSERT INTO Book.BooksLocation([Floor], [Shelf]) VALUES (1,	'1F');
INSERT INTO Book.BooksLocation([Floor], [Shelf]) VALUES (1,	'1G');
INSERT INTO Book.BooksLocation([Floor], [Shelf]) VALUES (2,	'2A');
INSERT INTO Book.BooksLocation([Floor], [Shelf]) VALUES (2,	'2B');
INSERT INTO Book.BooksLocation([Floor], [Shelf]) VALUES (2,	'2C');
INSERT INTO Book.BooksLocation([Floor], [Shelf]) VALUES (2,	'2D');
INSERT INTO Book.BooksLocation([Floor], [Shelf]) VALUES (2,	'2E');
INSERT INTO Book.BooksLocation([Floor], [Shelf]) VALUES (2,	'2F');
INSERT INTO Book.BooksLocation([Floor], [Shelf]) VALUES (2,	'2G');
INSERT INTO Book.BooksLocation([Floor], [Shelf]) VALUES (3,	'3A');
INSERT INTO Book.BooksLocation([Floor], [Shelf]) VALUES (3,	'3B');
INSERT INTO Book.BooksLocation([Floor], [Shelf]) VALUES (3,	'3C');
INSERT INTO Book.BooksLocation([Floor], [Shelf]) VALUES (3,	'3D');
INSERT INTO Book.BooksLocation([Floor], [Shelf]) VALUES (3,	'3E');
INSERT INTO Book.BooksLocation([Floor], [Shelf]) VALUES (3,	'3F');
INSERT INTO Book.BooksLocation([Floor], [Shelf]) VALUES (3,	'3G');

--BOOKS
INSERT INTO Book.Books ([Name], [Author], [Gendre], [Year], [ISBN], [Amount], [BookLocationID]) VALUES ('El País Mantis',							'Isaias Nieto Sanches',	'Humor',	1971,	'99-7875-257-9',	3,	1);
INSERT INTO Book.Books ([Name], [Author], [Gendre], [Year], [ISBN], [Amount], [BookLocationID]) VALUES ('The Bartimaeus Trilogy',					'Jonathan Stroud',		'Fantasy',	1930,	'3-598-21500-2',	3,	2);
INSERT INTO Book.Books ([Name], [Author], [Gendre], [Year], [ISBN], [Amount], [BookLocationID]) VALUES ('Bas-Lag',									'China Mieville',		'Fantasy',	1940,	'88-8317-198-7',	3,	3);
INSERT INTO Book.Books ([Name], [Author], [Gendre], [Year], [ISBN], [Amount], [BookLocationID]) VALUES ('The Battle of Apocalypse',					'The Belgariad',		'Fantasy',	1958,	'957-701-421-6',	3,	4);
INSERT INTO Book.Books ([Name], [Author], [Gendre], [Year], [ISBN], [Amount], [BookLocationID]) VALUES ('Beaty',									'Roald Dahl',			'Fantasy',	1939,	'88-8317-201-9',	3,	5);
INSERT INTO Book.Books ([Name], [Author], [Gendre], [Year], [ISBN], [Amount], [BookLocationID]) VALUES ('Another Kind of Life',						'Catherine Dunne',		'History',	1921,	'957-701-425-3',	3,	6);
INSERT INTO Book.Books ([Name], [Author], [Gendre], [Year], [ISBN], [Amount], [BookLocationID]) VALUES ('The Fall of Light ',						'Nialll Williams',		'History',	1912,	'7-6163-5644-8',	3,	7);
INSERT INTO Book.Books ([Name], [Author], [Gendre], [Year], [ISBN], [Amount], [BookLocationID]) VALUES ('The Hunger',								'David Rees',			'History',	1957,	'3-598-21505-3',	3,	8);
INSERT INTO Book.Books ([Name], [Author], [Gendre], [Year], [ISBN], [Amount], [BookLocationID]) VALUES ('Trinity',									'Redemption',			'History',	1943,	'7-6163-5647-4',	3,	9);
INSERT INTO Book.Books ([Name], [Author], [Gendre], [Year], [ISBN], [Amount], [BookLocationID]) VALUES ('Lion of Ireland',							'J.G.Farrell',			'History',	1975,	'88-8317-199-6',	2,	10);
INSERT INTO Book.Books ([Name], [Author], [Gendre], [Year], [ISBN], [Amount], [BookLocationID]) VALUES ('King Hereafter',							'Dorothy Dunnett',		'History',	1944,	'7-6163-5647-9',	2,	11);
INSERT INTO Book.Books ([Name], [Author], [Gendre], [Year], [ISBN], [Amount], [BookLocationID]) VALUES ('The Third Witch',							'Rebecca Reisert',		'History',	1935,	'957-701-425-2',	2,	12);
INSERT INTO Book.Books ([Name], [Author], [Gendre], [Year], [ISBN], [Amount], [BookLocationID]) VALUES ('Guardian of the Dawn',						'Amita Kenekar',		'History',	1966,	'7-6163-5649-4',	2,	13);
INSERT INTO Book.Books ([Name], [Author], [Gendre], [Year], [ISBN], [Amount], [BookLocationID]) VALUES ('The Far Pavilions ',						'M. M. Kaye',			'History',	1981,	'88-8317-193-8',	2,	14);
INSERT INTO Book.Books ([Name], [Author], [Gendre], [Year], [ISBN], [Amount], [BookLocationID]) VALUES ('Shei Shomoy',								'Nunil Gangopadhyay',	'History',	1993,	'7-6163-5650-5',	2,	15);
INSERT INTO Book.Books ([Name], [Author], [Gendre], [Year], [ISBN], [Amount], [BookLocationID]) VALUES ('Empire of the Moghul',						'Alex Rutherford',		'History',	1956,	'3-598-21513-4',	2,	16);
INSERT INTO Book.Books ([Name], [Author], [Gendre], [Year], [ISBN], [Amount], [BookLocationID]) VALUES ('Don Quixote',								'Miguel de Cervantes',	'Novel',	1612,	'957-701-431-7',	2,	17);
INSERT INTO Book.Books ([Name], [Author], [Gendre], [Year], [ISBN], [Amount], [BookLocationID]) VALUES ('Tale of Two Cities',						'Charles Dickens',		'History',	1859,	'989-54-7792-1',	2,	18);
INSERT INTO Book.Books ([Name], [Author], [Gendre], [Year], [ISBN], [Amount], [BookLocationID]) VALUES ('The Alchemist',							'Paulo Coelho',			'Adventure',1988,	'989-54-7781-4',	2,	19);
INSERT INTO Book.Books ([Name], [Author], [Gendre], [Year], [ISBN], [Amount], [BookLocationID]) VALUES ('The Little Prince',						'Antoine de Saint',		'Novel',	1943,	'3-598-21508-8',	2,	20);
INSERT INTO Book.Books ([Name], [Author], [Gendre], [Year], [ISBN], [Amount], [BookLocationID]) VALUES ('The Da Vinci Code',						'Dan Brown',			'Mystery',	2003,	'989-54-7799-6',	4,	21);
INSERT INTO Book.Books ([Name], [Author], [Gendre], [Year], [ISBN], [Amount], [BookLocationID]) VALUES ('The Hobbit',								'J. R. R. Tolkien',		'Fantasy',	1997,	'88-8317-192-9',	6,	13);
INSERT INTO Book.Books ([Name], [Author], [Gendre], [Year], [ISBN], [Amount], [BookLocationID]) VALUES ('And Then There Were None',					'Agatha Christie',		'Crime',	1937,	'3-598-21523-1',	5,	6);
INSERT INTO Book.Books ([Name], [Author], [Gendre], [Year], [ISBN], [Amount], [BookLocationID]) VALUES ('Dream of the Red Chamber',					'Cao Xueqin',			'Novel',	1754,	'989-54-7752-3',	5,	3);
INSERT INTO Book.Books ([Name], [Author], [Gendre], [Year], [ISBN], [Amount], [BookLocationID]) VALUES ('Alice in Wonderland',						'Lewis Carroll',		'Fiction',	1865,	'957-701-444-6',	4,	4);
INSERT INTO Book.Books ([Name], [Author], [Gendre], [Year], [ISBN], [Amount], [BookLocationID]) VALUES ('Tree and Leaf',							'J. R. R. Tolkien',		'Fantasy',	1964,	'90-5487-843-2',	6,	13);
INSERT INTO Book.Books ([Name], [Author], [Gendre], [Year], [ISBN], [Amount], [BookLocationID]) VALUES ('Bilbo’s Last Song',						'J. R. R. Tolkien',		'Fantasy',	1951,	'90-5487-861-9',	6,	13);
INSERT INTO Book.Books ([Name], [Author], [Gendre], [Year], [ISBN], [Amount], [BookLocationID]) VALUES ('The Return of the Shadow',					'J. R. R. Tolkien',		'Fantasy',	1974,	'90-5487-851-3',	6,	13);
INSERT INTO Book.Books ([Name], [Author], [Gendre], [Year], [ISBN], [Amount], [BookLocationID]) VALUES ('The Treason of Isengard',					'J. R. R. Tolkien',		'Fantasy',	1978,	'90-5487-844-5',	6,	13);
INSERT INTO Book.Books ([Name], [Author], [Gendre], [Year], [ISBN], [Amount], [BookLocationID]) VALUES ('Harry Potter and the Half-Blood Prince',	'J. K. Rowling',		'Fantasy',	2005,	'3-598-21533-2',	8,	18);
INSERT INTO Book.Books ([Name], [Author], [Gendre], [Year], [ISBN], [Amount], [BookLocationID]) VALUES ('Harry Potter and the Chamber of Secrets',	'J. K. Rowling',		'Fantasy',	1998,	'3-598-21584-3',	8,	18);
INSERT INTO Book.Books ([Name], [Author], [Gendre], [Year], [ISBN], [Amount], [BookLocationID]) VALUES ('Harry Potter and the Prisoner of Azkaban',	'J. K. Rowling',		'Fantasy',	1998,	'3-598-21521-4',	8,	18);
INSERT INTO Book.Books ([Name], [Author], [Gendre], [Year], [ISBN], [Amount], [BookLocationID]) VALUES ('Harry Potter and the Goblet of Fire',		'J. K. Rowling',		'Fantasy',	2000,	'3-598-21566-5',	8,	18);
INSERT INTO Book.Books ([Name], [Author], [Gendre], [Year], [ISBN], [Amount], [BookLocationID]) VALUES ('Harry Potter and the Order of the Phoenix','J. K. Rowling',		'Fantasy',	2003,	'3-598-21537-6',	8,	18);
INSERT INTO Book.Books ([Name], [Author], [Gendre], [Year], [ISBN], [Amount], [BookLocationID]) VALUES ('Harry Potter and the Deathly Hallows',		'J. K. Rowling',		'Fantasy',	2007,	'3-598-21533-8',	8,	18);
INSERT INTO Book.Books ([Name], [Author], [Gendre], [Year], [ISBN], [Amount], [BookLocationID]) VALUES ('A Game of Thrones',						'G. R. R. Martin',		'Fantasy',	1996,	'83-7123-174-2',	7,	15);
INSERT INTO Book.Books ([Name], [Author], [Gendre], [Year], [ISBN], [Amount], [BookLocationID]) VALUES ('A Clash of Kings',							'G. R. R. Martin',		'Fantasy',	1999,	'83-7123-175-8',	7,	15);
INSERT INTO Book.Books ([Name], [Author], [Gendre], [Year], [ISBN], [Amount], [BookLocationID]) VALUES ('A Storm of Swords',						'G. R. R. Martin',		'Fantasy',	2000,	'83-7123-176-3',	7,	15);
INSERT INTO Book.Books ([Name], [Author], [Gendre], [Year], [ISBN], [Amount], [BookLocationID]) VALUES ('A Feast for Crows',						'G. R. R. Martin',		'Fantasy',	2005,	'83-7123-177-4',	7,	15);
INSERT INTO Book.Books ([Name], [Author], [Gendre], [Year], [ISBN], [Amount], [BookLocationID]) VALUES ('A Dance with Dragons',						'G. R. R. Martin',		'Fantasy',	2011,	'83-7123-180-2',	7,	15);
INSERT INTO Book.Books ([Name], [Author], [Gendre], [Year], [ISBN], [Amount], [BookLocationID]) VALUES ('The Winds of Winter',						'G. R. R. Martin',		'Fantasy',	2016,	'83-7123-190-5',	15,	15);

--RANDOM GENERATED EMPLOYEES
INSERT INTO Employee.Employees (FirstName, LastName, Gender, JobTitle, Salary, HireDate, Email, PhoneNumber, City, [Address]) VALUES ('Barbara', 'James',  'Female', 'Custodian', 3500, '09/13/2015', 'bjames0@newyorker.com',		'48-(529)649-4002',	'Glasgow', '135 Steensland Circle');
INSERT INTO Employee.Employees (FirstName, LastName, Gender, JobTitle, Salary, HireDate, Email, PhoneNumber, City, [Address]) VALUES ('Doris',   'Rose',   'Female', 'Librarian', 3000, '02/12/2016', 'drose1@drupal.org',			'62-(177)122-6373',	'Glasgow', '218 Village Center');
INSERT INTO Employee.Employees (FirstName, LastName, Gender, JobTitle, Salary, HireDate, Email, PhoneNumber, City, [Address]) VALUES ('Judith',  'Dunn',   'Female', 'Librarian', 3000, '08/01/2016', 'jdunn2@independent.co.uk',	'48-(529)494-9746',	'Glasgow', '8 Linden Junction');
INSERT INTO Employee.Employees (FirstName, LastName, Gender, JobTitle, Salary, HireDate, Email, PhoneNumber, City, [Address]) VALUES ('David',   'Foster', 'Male',   'Cleaner',   2350, '11/08/2015', 'dfoster3@macromedia.com',	'86-(191)118-5022', 'Glasgow', '67 Hoepker Point');
INSERT INTO Employee.Employees (FirstName, LastName, Gender, JobTitle, Salary, HireDate, Email, PhoneNumber, City, [Address]) VALUES ('Martin',  'Greene', 'Male',   'Manager',   4500, '05/26/2015', 'mgreene4@yahoo.co.jp',		'86-(191)991-7151',	'Glasgow', '218 Village Center');


--RANDOM GENERATED Members
INSERT INTO Member.Members (FirstName, LastName, Email, PhoneNumber, Gender, City, JoinDate, SubscriptionStartDate, MembershipTypeID) VALUES ('Patrick',	'Ward',		'pward0@sourceforge.net',	'62-(815)789-3818',		'Male',	  'Glasgow',	'11/16/2015',	 '05/12/2016',	1);
INSERT INTO Member.Members (FirstName, LastName, Email, PhoneNumber, Gender, City, JoinDate, SubscriptionStartDate, MembershipTypeID) VALUES ('Pamela',		'Morales',	'pmorales@tripadvisor.com', '86-(194)769-7656',		'Female', 'Glasgow',	'03/13/2016',	 '05/12/2016',	3);
INSERT INTO Member.Members (FirstName, LastName, Email, PhoneNumber, Gender, City, JoinDate, SubscriptionStartDate, MembershipTypeID) VALUES ('Julie',		'Morrison', 'jmorrison2@joomla.org',	'63-(719)157-6269',		'Female', 'Glasgow',	'09/17/2016',	 '07/28/2016',	3);
INSERT INTO Member.Members (FirstName, LastName, Email, PhoneNumber, Gender, City, JoinDate, SubscriptionStartDate, MembershipTypeID) VALUES ('Matthew',	'Rogers',	'mrogers3@kickstarter.com', '63-(816)486-5475',		'Male',   'Glasgow',	'09/10/2016',	 '06/18/2016',	2);
INSERT INTO Member.Members (FirstName, LastName, Email, PhoneNumber, Gender, City, JoinDate, SubscriptionStartDate, MembershipTypeID) VALUES ('Heather',	'Ortiz',	'hortiz4@wp.com',			'355-(101)841-5097',	'Female', 'Glasgow',	'12/22/2015',	 '06/10/2016',	1);
INSERT INTO Member.Members (FirstName, LastName, Email, PhoneNumber, Gender, City, JoinDate, SubscriptionStartDate, MembershipTypeID) VALUES ('Bruce',		'Long',		'blong5@fda.gov',			'62-(533)235-7520',		'Male',   'Glasgow',	'07/19/2016',	 '06/19/2016',	2);
INSERT INTO Member.Members (FirstName, LastName, Email, PhoneNumber, Gender, City, JoinDate, SubscriptionStartDate, MembershipTypeID) VALUES ('Kathryn',	'Allen',	'kallen6@cnn.com',			'7-(938)571-2042',		'Female', 'Glasgow',	'08/24/2016',	 '06/02/2016',	3);
INSERT INTO Member.Members (FirstName, LastName, Email, PhoneNumber, Gender, City, JoinDate, SubscriptionStartDate, MembershipTypeID) VALUES ('Roy',		'Duncan',	'rduncan7@mac.com',			'7-(601)973-2709',		'Male',   'Glasgow',	'04/10/2016',	 '09/16/2016',	2);
INSERT INTO Member.Members (FirstName, LastName, Email, PhoneNumber, Gender, City, JoinDate, SubscriptionStartDate, MembershipTypeID) VALUES ('Ashley',		'Henry',	'ahenry8@exblog.jp',		'51-(686)375-3129',		'Female', 'Glasgow',	'03/16/2016',	 '06/14/2016',	3);
INSERT INTO Member.Members (FirstName, LastName, Email, PhoneNumber, Gender, City, JoinDate, SubscriptionStartDate, MembershipTypeID) VALUES ('Teresa',		'Jones',	'tjones9@ucla.edu',			'62-(248)393-9177',		'Female', 'Glasgow',	'10/06/2015',	 '05/07/2016',	1);
INSERT INTO Member.Members (FirstName, LastName, Email, PhoneNumber, Gender, City, JoinDate, SubscriptionStartDate, MembershipTypeID) VALUES ('Barbara',	'Howell',	'bhowella@ted.com',			'57-(890)205-1320',		'Female', 'Glasgow',	'03/19/2016',	 '06/22/2016',	2);
INSERT INTO Member.Members (FirstName, LastName, Email, PhoneNumber, Gender, City, JoinDate, SubscriptionStartDate, MembershipTypeID) VALUES ('Nicole',		'Little',	'nlittleb@sfgate.com',		'977-(752)486-0583',	'Female', 'Glasgow',	'02/25/2016',	 '05/10/2016',	3);
INSERT INTO Member.Members (FirstName, LastName, Email, PhoneNumber, Gender, City, JoinDate, SubscriptionStartDate, MembershipTypeID) VALUES ('Craig',		'Robinson', 'crobinsonc@yelp.com',		'86-(423)463-0567',		'Male',   'Glasgow',	'09/15/2015',	 '09/03/2016',	2);
INSERT INTO Member.Members (FirstName, LastName, Email, PhoneNumber, Gender, City, JoinDate, SubscriptionStartDate, MembershipTypeID) VALUES ('Fred',		'Frazier',	'ffrazierd@umich.edu',		'86-(133)790-2072',		'Male',   'Glasgow',	'09/19/2016',	 '09/11/2016',	2);
INSERT INTO Member.Members (FirstName, LastName, Email, PhoneNumber, Gender, City, JoinDate, SubscriptionStartDate, MembershipTypeID) VALUES ('Margaret',	'Sanders',	'msanderse@phpbb.com',		'86-(854)176-6918',		'Female', 'Glasgow',	'05/02/2016',	 '08/24/2016',	1);
INSERT INTO Member.Members (FirstName, LastName, Email, PhoneNumber, Gender, City, JoinDate, SubscriptionStartDate, MembershipTypeID) VALUES ('Patricia',	'Warren',	'pwarrenf@behance.net',		'63-(150)587-9209',		'Female', 'Glasgow',	'09/21/2015',	 '06/02/2016',	1);
INSERT INTO Member.Members (FirstName, LastName, Email, PhoneNumber, Gender, City, JoinDate, SubscriptionStartDate, MembershipTypeID) VALUES ('Robin',		'Carpenter','rcarpenterg@live.com',		'34-(431)491-1334',		'Female', 'Glasgow',	'09/19/2015',	 '08/22/2016',	3);
INSERT INTO Member.Members (FirstName, LastName, Email, PhoneNumber, Gender, City, JoinDate, SubscriptionStartDate, MembershipTypeID) VALUES ('Raymond',	'Mendoza',	'rmendozah@yale.edu',		'380-(634)557-7872',	'Male',   'Glasgow',	'01/06/2016',	 '08/15/2016',	3);
INSERT INTO Member.Members (FirstName, LastName, Email, PhoneNumber, Gender, City, JoinDate, SubscriptionStartDate, MembershipTypeID) VALUES ('Sandra',		'Spencer',	'sspenceri@nasa.gov',		'63-(624)184-9708',		'Female', 'Glasgow',	'08/07/2016',	 '06/23/2016',	3);
INSERT INTO Member.Members (FirstName, LastName, Email, PhoneNumber, Gender, City, JoinDate, SubscriptionStartDate, MembershipTypeID) VALUES ('Roy',		'Lawson',	'rlawsonj@google.ru',		'48-(329)643-3199',		'Male',   'Glasgow',	'07/13/2016',	 '09/10/2016',	3);
INSERT INTO Member.Members (FirstName, LastName, Email, PhoneNumber, Gender, City, JoinDate, SubscriptionStartDate, MembershipTypeID) VALUES ('Marilyn',	'Knight',	'mknightk@bloglovin.com',	'86-(985)135-5123',		'Female', 'Glasgow',	'02/06/2016',	 '07/31/2016',	2);
INSERT INTO Member.Members (FirstName, LastName, Email, PhoneNumber, Gender, City, JoinDate, SubscriptionStartDate, MembershipTypeID) VALUES ('Jimmy',		'Weaver',	'jweaverl@infoseek.co.jp',	'1-(915)903-1625',		'Male',   'Glasgow',	'12/08/2015',	 '08/10/2016',	2);
INSERT INTO Member.Members (FirstName, LastName, Email, PhoneNumber, Gender, City, JoinDate, SubscriptionStartDate, MembershipTypeID) VALUES ('Diana',		'Cruz',		'dcruzm@tmall.com',			'86-(230)199-9065',		'Female', 'Glasgow',	'03/22/2016',	 '08/02/2016',	2);
INSERT INTO Member.Members (FirstName, LastName, Email, PhoneNumber, Gender, City, JoinDate, SubscriptionStartDate, MembershipTypeID) VALUES ('Mildred',	'Warren',	'marmstrongn@hp.com',		'371-(537)466-9162',	'Female', 'Glasgow',	'09/02/2015',	 '06/08/2016',	1);
INSERT INTO Member.Members (FirstName, LastName, Email, PhoneNumber, Gender, City, JoinDate, SubscriptionStartDate, MembershipTypeID) VALUES ('Amy',		'Mason',	'amasono@reuters.com',		'595-(809)364-0572',	'Female', 'Glasgow',	'12/11/2015',	 '06/17/2016',	3);
INSERT INTO Member.Members (FirstName, LastName, Email, PhoneNumber, Gender, City, JoinDate, SubscriptionStartDate, MembershipTypeID) VALUES ('Juan',		'Moore',	'jmoorep@vimeo.com',		'1-(701)549-7456',		'Male',   'Glasgow',	'11/07/2015',	 '09/11/2016',	1);
INSERT INTO Member.Members (FirstName, LastName, Email, PhoneNumber, Gender, City, JoinDate, SubscriptionStartDate, MembershipTypeID) VALUES ('Joan',		'Morgan',	'jmorganq@mapquest.com',	'374-(436)339-2092',	'Female', 'Glasgow',	'12/24/2015',	 '07/07/2016',	2);
INSERT INTO Member.Members (FirstName, LastName, Email, PhoneNumber, Gender, City, JoinDate, SubscriptionStartDate, MembershipTypeID) VALUES ('Peter',		'Hawkins',	'phawkinsr@devhub.com',		'47-(429)398-6719',		'Male',   'Glasgow',	'06/08/2016',	 '09/04/2016',	1);
INSERT INTO Member.Members (FirstName, LastName, Email, PhoneNumber, Gender, City, JoinDate, SubscriptionStartDate, MembershipTypeID) VALUES ('Janice',		'Schmidt',	'jschmidts@nyu.edu',		'86-(956)892-4711',		'Female', 'Glasgow',	'07/25/2016',	 '06/05/2016',	1);


INSERT INTO Employee.Users (EmployeeID,[Login],[Password],[Disabled]) VALUES (1001,'Librarian1',dbo.MD5PasswordHash('password'),0); 
INSERT INTO Employee.Users (EmployeeID,[Login],[Password],[Disabled]) VALUES (1002,'Librarian2',dbo.MD5PasswordHash('ASD123'),0); 
INSERT INTO Employee.Users (EmployeeID,[Login],[Password],[Disabled]) VALUES (1004,'Meneger1',dbo.MD5PasswordHash('qwerty1'),0);

INSERT INTO Book.BorrowedBooks (MemberID,BookID,LendDate,LendedBy) VALUES (10023,5,'6/16/2016'	,1001);
INSERT INTO Book.BorrowedBooks (MemberID,BookID,LendDate,LendedBy) VALUES (10021,16,'9/22/2016'	,1001);
INSERT INTO Book.BorrowedBooks (MemberID,BookID,LendDate,LendedBy) VALUES (10013,3,'12/30/2015',1001);
INSERT INTO Book.BorrowedBooks (MemberID,BookID,LendDate,LendedBy) VALUES (10021,4,'8/22/2016'	,1001);
INSERT INTO Book.BorrowedBooks (MemberID,BookID,LendDate,LendedBy) VALUES (10013,4,'4/4/2016'	,1001);
INSERT INTO Book.BorrowedBooks (MemberID,BookID,LendDate,LendedBy) VALUES (10011,10,'5/11/2016'	,1001);
INSERT INTO Book.BorrowedBooks (MemberID,BookID,LendDate,LendedBy) VALUES (10010,5,'11/19/2015',1001);
INSERT INTO Book.BorrowedBooks (MemberID,BookID,LendDate,LendedBy) VALUES (10011,12,'6/15/2016'	,1001);
INSERT INTO Book.BorrowedBooks (MemberID,BookID,LendDate,LendedBy) VALUES (10010,5,'6/8/2016'	,1001);
INSERT INTO Book.BorrowedBooks (MemberID,BookID,LendDate,LendedBy) VALUES (10011,13,'7/1/2016'	,1001);

EXEC spLendABook 10001,40,1001
EXEC spLendABook 10001,39,1001
EXEC spLendABook 10002,38,1001
EXEC spLendABook 10008,38,1002
EXEC spLendABook 10004,33,1001
EXEC spLendABook 10005,32,1002
EXEC spLendABook 10007,31,1001
EXEC spLendABook 10027,22,1002
EXEC spLendABook 10017,34,1001
EXEC spLendABook 10026,24,1001
EXEC spLendABook 10017,18,1002
EXEC spLendABook 10016,2, 1001
EXEC spLendABook 10017,15,1002