# Legacy Rerater Mini, Planning Document

## I want to...

- Create a C# Console App
- User interactions through the console with exception handling
- Single User
- Persist data to a local file on my machine*
- Separate my code/logic into 3-4 layers. (Presentation (UI the user sees), Data Access (Communicating with our data store), Controllers/Business Logic, Models)

## Application Ideas

### Policy re-rater

- Accounts for more than one policy
- Different categories of items that go into premium calculation (occurrences (a.k.a accidents, convictions and suspensions), discounts)
- Description
- Date of Purchase of the policies
- In-force date, which determines the rategen (the initial demonstration asked for entering the rategen manually.  Here is derived from the in-force date)
- any other ...

### Models (What are we trying to store/work with)

- User
  - userId (int)
  - userName (string)

- Groups - Things Common to most/all item types (This is our parent/super class)
  - policyId (int/maybe guid)
  - ownerId (int referencing someone's userId)
  - item category (string) ?
  - Original Cost (double)
  - Purchase Date (DateTime)
  - Description (string)
 
- Subgroup
-   Rerating to a new rategen


### User Stories/Features

- As a User I want to be able to create a profile and log in
  - Present options via a menu in the console to the user (Presentation layer)
  - We want to take their input and either (Presentation layer)
    - create a new profile with a given username, and an auto-generated userID (business logic/controller)
      - we need to then store this profile in our data store (data access layer)
      - if a given username already exists, prompt the user to provide a different username
    - OR we want to pull up their information (business logic/controller)
      - we need to reach into our data store (file, or DB, etc) and grab their profile and associated info (data access layer).
- As a user I want to be able to add a group
- As a user I want to be able to add a sub-group
- There is no use case for deleting a group by a user.  Deletion is automated and it happens every 21 days
  
