# ChildcareScouter.MVC
ElevenFifty Final RedBadge FullStack MVC project 
 
Craddle to Community
(ChildCareScouter)




Table of Contents:

Mission Statement......1

Database........2

Features........3

TrelloLink......4

Schedule.....5

Final Notes....6





Mission Statement 

	The objective is to assist users(including many different stakeholders alike) with their search in childcare programs in these trying times. This MVC Web App will take all the hassle out of searching for childcare providers/programs. Whether each indivisual user wants to enroll their children(dependents) in different childcare programs and/or enbark on a career as a  childcare provider.          

Database
This is where your team writes out how your database will look like. List out each table, the columns (include the dataTypes), and the database associations your project will have on the server-side.

Table 1: Programs
 



Table 2: Providers : Person
 



Table 3: Child : Person
 



Optional:

Additional Tables:  [Careers], [Curriculums],[Enrollment], [Reviews], [Allergen Grid], [Child(Persons)], [Staff(Persons)]

 

 

 

 

Endpoints?
GET: /Program(Program by ID)/Delete/Update/Edit/Details

GET: /Program(List of Programs)/Create

POST: /Program/Create [Role: Childcare Programs] 

DELETE: /Program/Delete{id} [Role: Childcare Programs]

PUT: /Program/Update{id} [Role: Childcare Programs]

GET: /CareerPostions by ID)/Delete/Update/Edit/Details

GET : /Career(List of Positions)/Create 

POST : /Career/Create [Role: Admin]

POST : /Career/ Apply [Role Users]

DElETE : /Career/Delete{id} [Role:Admin]

PUT : /Career/Update{id} [Role:Admin] 

REVIEWS /Reviews/(similar to Previous)

ENROLLMENTS : /Enrollments/ (similar to Previous)

(abstract class) PERSONS : /Children/Parents/Providers/ (similar to Previous) 



Features
Features are instances or examples of different pieces of functionality. This is where your team lists out the features you are planning on implementing. Consider the different steps and logic those features require to do the expected job. This could include fetching data from a 3rd party API or simply looping over data from your server. Differentiate between your version 1.0 or MVP (minimal viable product) and version 2.0 or stretch goals. 

Version 1.0 / MVP	Version 2.0 / Stretch Goals
⦁	 (Admin) the ability to see all Applications in the careers sections.
⦁	 (Users) ability to Report each Childcare program.
⦁	 (Childcare Programs) ability to Post their program unto the site. 
⦁	 (Users) ability to apply for provider positions. 
⦁	 (Users) ability to see a list of Reviews.
⦁	 (Users) ability to see only the Childcare programs that mostly fits their schedule and childs basic needs  
⦁	 (All Users) ability to see the Curriculums, Enrollment DeadLines, Admissions, Registration, and Meal Plans.
⦁	 (Admin) ability give access to users who are enrolled to review that specific program 	⦁	 Create a soft Delete functionality
⦁	 Pop-up admin ChatBot
⦁	 Use different templates
⦁	 Use Google Maps API
⦁	 (Users) ability to get most Recommended Childcare programs
⦁	 (Admin) ability to recommend great canadates for each childcare program  
⦁	  (All Users) ability to see the Curriculums, Enrollment DeadLines, Admissions, Registration, and Meal Plans.
⦁	  (Admin) ability to ban a user from the sit for a period of time. 

