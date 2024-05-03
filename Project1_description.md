# TrackMyStuff Planning Document

## I want to...

- Create a C# Console App
- User interactions through the console with exception handling
- Single User
- Persist data to a local file on my machine*
- Separate my code/logic into 3-4 layers. (Presentation (UI the user sees), Data Access (Communicating with our data store), Controllers/Business Logic, Models)

## Application Ideas

### Policy re-rating tracker (More code)

- Accounts for more than one policy
- Different categories of items that go into premium calculation (occurrences (a.k.a accidents, convictions and suspensions), discounts)
- Storing the original value of the items
- description
- Date of Purchase of the policies
- In-force date, which determines the rategen (the initial demonstration asked for entering the rategen manually.  Here is derived from the in-force date)
- any other ...

## Track My Stuff

### Models (What are we trying to store/work with)

- User
  - userId (int)
  - userName (string)

- Policy - Things Common to most/all item types (This is our parent/super class)
  - policyId (int/maybe guid)
  - ownerId (int referencing someone's userId)
  - item category (string) ?
  - Original Cost (double)
  - Purchase Date (DateTime)
  - Description (string)

- PP Auto - inherit/extends our base Policy class
  - name (string)
  - vehicleType (string)
  - occurrences (double)
  - discounts (double)
    - some discounts are only applicable to PP auto

- RV - inherit/extends our base Policy class
  - name (string)
  - vehicleType (string)
  - occurrences (double)
  - discounts (double)
    -some discounts are only available for RV

### User Stories/Features

- As a User I want to be able to create a profile and log in
  - Present options via a menu in the console to the user (Presentation layer)
  - We want to take their input and either (Presentation layer)
    - create a new profile with a given username, and an auto-generated userID (business logic/controller)
      - we need to then store this profile in our data store (data access layer)
      - if a given username already exists, prompt the user to provide a different username
    - OR we want to pull up their information (business logic/controller)
      - we need to reach into our data store (file, or DB, etc) and grab their profile and associated info (data access layer).
