# TT_Project

## Project Overview

### Application Description

This application is to allow motorcycle riders to enter into the TT races. This is a road race that happens on the Isle of Man once a year and riders need to complete an entry form for each race they would like to race in.
The entries need to be checked to meet the criteria by race management, from which they will be moved from pending to approved or rejected.

### Project Goals

* Create a user interface, database and business layer
* Business layer to include testing
* Application should handle errors and invalid inputs
* Two or more linking tables
* Clear and concise documentation of the process



## Class Diagrams

![Class_Diagram.JPG](https://github.com/Breesha/TT_Project/blob/main/Images/Class_Diagram.JPG)

## WPF

![WPF_FirstPage.JPG](https://github.com/Breesha/TT_Project/blob/main/Images/WPF_FirstPage.JPG)

![WPF_SecondPage.JPG](https://github.com/Breesha/TT_Project/blob/main/Images/WPF_SecondPage.JPG)

## Sprint Breakdowns

![First_ProjectBoard.JPG](https://github.com/Breesha/TT_Project/blob/main/Images/First_ProjectBoard.JPG)

### Sprint 1 - Tuesday 1st December 2020

By the end of this sprint I aim to have a database set up and interacting with the business  layer. The business layer should have methods to perform basic CRUD operations and from this have unit tests to check these methods.

#### Sprint Goals

* [ ] Complete project board
* [ ] Update epics and user stories
* [ ] Complete user story 0.1 - Create database
* [ ] complete user story 0.2 - Create business layer
* [ ] Complete user story 0.3 - CRUD tests
* [ ] Complete Agile documentation
* [ ] Complete Agile review
* [ ] Complete Agile retrospective
* [ ] Update README file
* [ ] Commit all changes to GitHub

#### Sprint Review

The project admin was completed early in the day which left lots of time for the rest of the tasks. The database was completed with several modifications throughout the day to link the tables effectively. The interface between database and code was created as well as a business layer and tests were started however, only some were fully coded and run.

Changes were pushed to GitHub, but the commits could be improved to have smaller changes more often to make the description clearer. The commits could also link to the user stories that were completed.

#### Sprint Retrospective

* Continue: Pace, I didn't overload myself on work so I am not behind on tasks.
* Continue: I should continue with the pace of work and work load for now.
* Start: I can start timeboxing my tasks to improve my time management.
* Start: I can start committing work more often.
* Due to the data tests in the morning, sprint 1 was shorter than other days so I can add more user stories to my sprint backlog for tomorrow.

![Sprint2_Start.JPG](https://github.com/Breesha/TT_Project/blob/main/Images/Sprint2_Start.JPG)

###  Sprint 2 - Wednesday 2nd December 2020

The main focus of this sprint is to create the WPF layer and add functionality to the GUI layer. This involves adding some more methods to the business layer to provide full functionality of the application. The rider profile and entry form is the main goal for the GUI today.

The only potential blocker for today is computer limitations, as it is still the early stages of creation.

#### Sprint Goals

* [ ] Complete user story 0.4 - Create WPF
* [ ] Complete user story 1.1 - Create rider account
* [ ] Complete user story 2.1 - Rider password protect
* [ ] Complete user story 3.1 - Rider race list
* [ ] Complete user story 3.3 - Rider entry submit option
* [ ] Update README
* [ ] Complete Agile review
* [ ] Complete Agile retrospective
* [ ] Commit all changes

#### Sprint Review

Despite starting the day on track, it became clear that I needed to change some links within my database such as foreign keys. This meant I had to spend more time than planned in the morning on correcting it. When advancing from this I created more methods and tests, which once again took more time than planned.

The WPF was then started and the structure of the application was laid out as planned. From this I started on the code behind of the programme and connected the business layer and the GUI.

#### Sprint Retrospective

* Stop: I spent too long focusing on the change of data in the database and implementing testing on this.
* Start: Researching problems as I am completing them instead of stopping my work to research the problem
* Start: I learnt today to add extra time to the plan so if there are problems there is allocated time for it and if not used, this time can be spent on finer details on the planned stages.
* Continue: Pacing of work completed, I got as far as I wanted to on the WPF but not the other sections due to them being pushed back by the database update.

![Sprint3_Start.JPG](https://github.com/Breesha/TT_Project/blob/main/Images/Sprint3_Start.JPG)

### Sprint 3 - Thursday 3rd December 2020

By the end of the sprint I want to have achieved the navigation windows within the GUI. As well as this, I want to build the code behind for the rider account and the details for their submitted entries with options to add more entries.

#### Sprint Goals

* [ ] Complete user story 3.1 - Rider race option list
* [ ] Complete user story 3.3 - Rider entry submit option
* [ ] Complete user story 1.2 - Rider password protected login
* [ ] Complete user story 4.1 - Rider view list of entries
* [ ] Complete user story 4.4 -  Rider entry delete option
* [ ] Update README
* [ ] Complete Agile review
* [ ] Complete Agile retrospective
* [ ] Commit all changes

#### Sprint Review

I set out to complete the same amount of tasks as I set yesterday with the hope that I wouldn't have unplanned interruptions. The three tasks that I didn't complete yesterday I added again with two more tasks also added. The problem from today was linking the data from the login page to the rider profile as it was just showing blank. This was a blocker as I couldn't fully complete the other user stories as they needed the information that wasn't being presented.

I successfully implemented the navigation windows by the end of the day and created a submit race entry button for the rider.

#### Sprint Retrospective

* Continue: Managing work load depending on timeboxing
* Continue: Pace of completing tasks.
* Start: Thinking of task order when completing user stories as one can be a blocker to another
* Start: Prioritising user stories that block other tasks.

![Sprint3_Start.JPG](https://github.com/Breesha/TT_Project/blob/main/Images/Sprint4_Start.JPG)

### Sprint 4 - Friday 4th December 2020

#### Sprint Goals

During this sprint I want to complete the rider race entry list to update as new entries are added, as well as adding delete buttons for entries and/or bike entries. I also aim to have the list displaying the information not the link page.

* [ ] Complete user story 4.1 - View entry list
* [ ] Complete user story 4.5 - View bike list
* [ ] Complete user story 4.4 - delete entries
* [ ] Update README
* [ ] Complete Agile review
* [ ] Complete Agile retrospective
* [ ] Commit all changes

#### Sprint Review

This was a shorter day for task completion as we as a group discussed what we needed to do for the presentation on Monday. Due to this, I didn't allocate too many tasks.

From the three tasks that were set, the two top prioritised tasks were completed (creating an entry and bike list that displays the data for the selected rider) and the third task, a delete for the list boxes was started. The tasks for today all linked so this was a blocker as I couldn't move onto the next task until the current one was completed.

#### Sprint Retrospective

* Continue: prioritising user stories 
* Continue: completing user stories that link in the same sprint, so the coding can be recreated appropriately with the method clear in my mind
* Continue: keeping the contents of the day outside of the sprint in mind when adding user stories to the sprint backlog to not overload myself
* Start: Take time at the start of the day to not just think about the blockers of the sprint but also how these can be affecting all user stories. From this a contingence plan can be drafted instead of just being stuck on a task for too long

![Sprint5_Start.JPG](https://github.com/Breesha/TT_Project/blob/main/Images/Sprint5_Start.JPG)

### Sprint 5 - Sunday 6th December 2020

#### Sprint Goals

This was the last full sprint of the project, so the main aim was to clear up the application. This meant to make it more user friendly and clear on the layout of the WPF. On top of this, the application had the final features added to it to allow full CRUD functionality.

* [ ] Complete user story 4.4 - Rider delete race entry
* [ ] Complete user story 4.6 - Rider delete bike entry
* [ ] Complete user story 3.2 - Rider race restrictions
* [ ] Complete user story 4.3 - Rider update details
* [ ] Complete user story 6.1 - WPF make pretty
* [ ] Record demo for presentation
* [ ] Update README
* [ ] Include class diagram (README)
* [ ] Include WPF images (README)
* [ ] Complete Agile review
* [ ] Complete Agile retrospective
* [ ] Commit all changes

#### Sprint Review

Overall, this was a very successful sprint as all essential tasks were completed. This meant that  it was fully functioning and met the requirements. Although all tasks weren't completed fully, the two delete buttons and update button became fully functional.

The amount of user stories was small for this sprint as WPF visuals was the main focus. During this there was a problem with making the image on the Sign In page visible but this was achieved and a smooth and flowing layout.

#### Sprint Retrospective

* Start: I should have tested all functions throughout the code changes, checking the change didn't affect further code
* Start: Having full run-throughs of using all functions to check for exceptions

* Continue: Focusing on the right task, priorities were correct.

![Sprint6_Start.JPG](https://github.com/Breesha/TT_Project/blob/main/Images/Sprint6_Start.JPG)

## Sprint 6 - Monday 7th December 2020

### Sprint Goals

This sprint was for final checks and preparation for the group presentation. This meant that there was no user stories to be completed but instead touch up the previous completed user stories to make them achieve more than the acceptance criteria. For example, the layout of the WPF and completing further tests.

* [ ] Complete final tests
* [ ] Update README
* [ ] Presentation preparation
* [ ] Complete Agile Review
* [ ] Complete Agile Retrospective
* [ ] Commit all changes

### Sprint Review

I was aware that this sprint was to just make small changes to the project. The presentation preparation as a group and individually took up a large amount of the day so I could achieve what I wanted in the available time. From further manual testing I discovered that the password method I have created lets you log in with any password that has been saved, not necessarily the specific password expected. This will be added to the future features that I wish to implement/ change. 

### Sprint Retrospective

I planned time well to accommodate the other plans during this sprint.

* Continue: planning with external factors involved
* Start: manual testing of all areas sooner

![Final_ProjectBoard.JPG](https://github.com/Breesha/TT_Project/blob/main/Images/Final_ProjectBoard.JPG)

## Project Sprint Review

The process I followed during this project was to create the database first, fill this with appropriate data and then to implement the business layer to interact with the database. At this point I created the CRUD testing before moving to the WPF creation. The test all pass and check the functionality of the business layer.

The project specification was to create an application that consists of a WPF front end, SQL database backend with at least 2 linking tables. The specification also included the use of entity framework and a business layer with logic. Therefore, the project MVP was achieved and so the project is considered successful.

Use of Git and GitHub was very frequent, so versions of the project weren't greatly varied when trying to track back any errors or changes to code. The README was updated multiple times a day so the information inputted was recently completed and clear in the mind. This meant progress was closely monitored and each sprint could be planned in accordance with progress.



## Project Sprint Retrospective

I started the project very positive as I had planned which tables would be needed for the database and how these would link to each other, if this was needed. I started with a small amount of tasks within my sprint 1 and 2 which meant I didn't feel overwhelmed at the start. From the way I planned my user stories and sprints I started each stage of the requirements one at a time to help my computer cope with the demand, my main blocker was the performance of my computer during this project.

Despite some challenges faced when linking the navigation windows and the selected rider, I stayed positive throughout the project and enjoyed completing it. With the help of Agile documentation I stayed on track and achieved the MVP.



