# DataBased
When considering which database to select for a project, the choice often boils down to SQL vs NoSQL databases (relational vs non-relational databases. There are many great choices for each paradigm, each with their own trade-offs. 

## Reason for Project
In implementing a database, we can get a clearer picture of what's going on under the hood - what design decisions have been made, how data is stored, how performant the database is, how well the database scales, etc. 
This project implements a simple relational database, that gives a good idea of what happens under the hood in a database and can be hooked in to projects to give a greater overview of the underlying calls that get made.

## Interesting Reads:
- https://www.coursera.org/articles/nosql-vs-sql
- https://medium.com/@marceloboeira/why-you-should-build-your-own-nosql-database-9bbba42039f5
- https://github.com/codecrafters-io/build-your-own-x?tab=readme-ov-file#build-your-own-database
- https://www.codeproject.com/Articles/1029838/Build-Your-Own-Database
- https://www.mongodb.com/resources/compare/mongodb-vs-redis
- https://wiki.mozilla.org/Performance/Avoid_SQLite_In_Your_Next_Firefox_Feature

## Different Attempts:
- Initially tried serializing and storing Base64 chunks in a file. 