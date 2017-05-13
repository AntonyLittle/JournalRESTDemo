A basic RESTful interface to a simple Journal database (Journal Owners have Journal Entries). Makes use of async / await for scalablility and provides a hierarchical API for access. Requests and responses are in JSON format.

apis/JournalOwner/ - all the journal owners (list)

apis/JournalOwner/1 - a specific journal owner (get/put/delete)

apis/JournalOwner/1/Entries - all journal entries for owner (list)

apis/JournalOwner/1/Entries/1 - a specific journal entry (get/put/delete)


This has been developed using Yodel for scaffolding and VS Code for editing. To build and run, use "dotnet restore", "dotnet build", then "dotnet run".
