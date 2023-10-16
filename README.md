# :clipboard: Test Queries Generation Tool

:pushpin: Currently, the project is included to my summary repository of demo projects:

:link: [Demo Projects Workshop 2023+](https://github.com/dar920910/Demo-Projects-Workshop)

---

## :sound: About the Project History

This project implements a tool to generate queries by a custom configuration:

- You can define a needed count of queries for different types of queries.
- You can configure both GET and SET queries via configuration files.
- You can scale GET/SET query units to generate scalable requests.

I created this software in 2021 to generate requests for low-level API of the Nexio AMP server to automatically prepare my test media base environment (~ 200 000 files) when I've worked in the [Nexio MOS](https://imaginecommunications.com/product/nexio-amp/) commercial project as QA engineer.

Now I finished migration of the tool from .NET Core 3.1 to **.NET 6** target platform.

The current implement of this project contains metadata fields' descriptions oriented to API protocol of the Nexio AMP server.
I plan to deprecate all Nexio AMP server mentions in this project to modify the project to a common-purpose tool in future.

## :dart: Planned Further Improvements

There are two important areas which should be improved when further development of this project:

:collision: How to modify the program to generate **common-purpose CRUD requests** (SQL, HTTP, GraphQL, etc.) ?

:collision: How to modify the program and its configuration files to define **custom metadata fields' types** ?

## :question: About the Repository Structure

This repository contains the following projects:

- **TestQueriesGenerator.Library** - implements the .NET class library for the project
- **TestQueriesGenerator.Testing** - implements NUnit-based unit tests for the project
- **TestQueriesGenerator.App.CLI** - implements the console application for the project

---

## :beginner: Quick Start

1. Run the program from the command-line to create the configuration default template when the first launching.
2. Configure target scalable entities via editing the **./~cfg/request.xml** file in your favorite text editor.
3. Configure query units with metadata fields via editing the "units" configuration files:
   - **./~cfg/units-get.xml** - to configure GET query units to **select** metadata field values,
   - **./~cfg/units-set.xml** - to configure SET query units to **create** metadata field values.
4. Use the same value of the **RuntimeID** attribute to scale generation of GET/SET query units.
5. Run the program after configuration creating is ready and wait for program's finishing.
6. Your configured requests are compiled and written to the **./~out/requests.test** output file.

**Note:** See the "Reference" section below to get help to create correct configuration of requests.

## :green_book: Reference

### :grey_question: Configuration Files

This section explains configuration parameters used for generation of requests:

- **./~cfg/request.xml** - Scalable entities configuration file
  - **RuntimeID** - user-defined identifier to link query units with a scalable entity
  - **NamePrefix** - user-defined prefix for a name of request' physical object
  - **FirstNumber** - user-defined first number of a physical object a scalable entity
  - **LastNumber** - user-defined last number of a physical object a scalable entity
- **./~cfg/units-get.xml** - GET query units configuration file
  - **MetadataSelectionQueryUnit** - represents a single GET query unit with metadata fields
  - **RuntimeID** - user-defined attribute related with a scalable entity for this query unit
- **./~cfg/units-set.xml** - SET query units configuration file
  - **ArrayOfMetadataCreationQueryUnit** - represents a single SET query unit with metadata fields
  - **RuntimeID** - user-defined attribute related with a scalable entity for this query unit

### :grey_question: Metadata Fields

Metadata fields are set via values of XML elements:

- Metadata fields for GET query units are set via boolean values:
  - "true" - enable a metadata field to compilation of GET requests
  - "false" - disable a metadata field to compilation of GET requests
- Metadata fields for SET query units are set via string values.

### :grey_question: Existing Limitations

The current implementation of this project supports only metadata fields for the specified domain area.
This is **media server environment** because the project was appeared as a specialized automation tool.
So, you **cannot define** your own metadata fields in the current program version.

---

## :whale: Run via Docker

1. Build app's Docker image via **Execute-DockerBuild.ps1** script.
2. Run the app from a new container via **Execute-DockerRun.ps1** script.

---

## :wrench: Build Source Code

Use **.NET 6 SDK** to build this project from source code.

---

## :email: Contribute the Project

[You can contact me using any contacts from my profile page](https://github.com/dar920910#speech_balloon-how-can-you-contact-with-me-)
