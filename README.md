## Justin Elder notes
I didn't finish all that I wanted to finish. If I had more time I would made all the api calls async/await methods. I would have made more tests and debugged the tests that failed.

Thank you for your time... and I'm looking forward in hearing from you.

Justin

# MercuryWorks - Coding Skills Test

You are working with a top-tier state university that needs help accessing their student and course data.

The university currently offers 350 different courses to over 10,000 students.

Currently, we have two rough C# interfaces, `IStudentAPI` and `ICourseAPI`, with only one method each.

## Refactoring

We would like to see how you would improve the example code. Please include a couple sentences describing your changes
along with the rationale, along with any additional changes you would have made given more time.

## API Design

Extend the `IStudentAPI` to include methods to satisfy the following criteria:

- Retrieve a list of all students
  - Expand this list query to filter the data by First name, Last name, Email, or no filter
  - Expand this list query to all ordering by First name, Last name, Email or no ordering
    - Ordering should be parameterized for ASC or DESC
- Find all students enrolled in a specified course
- Create an UPDATE endpoint that changes the Email Address for any Student
- Create an INSERT endpoint that adds a new student to the InMemory collection
- Create a DELETE endpoint that removes a given Student by Id
- Validate Student Email Addresses for format and uniqueness

Extend the `ICourseAPI` to include methods to satisfy the following criteria:

- Retrieve all courses, ordered by course name, as a pageable result set
- Find a single course by name
- Create an UPDATE endpoint that changes the title for a Course
- Create an INSERT endpoint that adds a new course
- Create a DELETE endpoint that removes a given Course by Id
- Validate for course name uniqueness

Error handling, validation, and proper response back to the User through your test cases is required and will be demonstrated in a
failing test case within your Unit tests

Implement your newly added interface methods.

## Unit Testing

In order to validate your API, what unit tests would you need to ensure it works as specified? 

Implement those tests in the test project.

## Time

Please limit your time to 2 hours.  Include a few sentences about the changes you made, or any additional changes you would make given more time.