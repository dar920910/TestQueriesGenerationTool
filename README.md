# TestQueriesGenerationTool

## About the Project

This project implements a tool to generate queries by a custom configuration:

- You can define a needed count of queries for different types of queries.
- You can configure both GET and SET queries via configuration files.

## About the Repository Structure

This repository contains the following projects:

- "TestQueriesGenerator.Library"
- "TestQueriesGenerator.Testing"
- "TestQueriesGenerator.App.CLI"

## Prerequisites

Use **.NET 6 SDK** to build the project from source code.

## Deployment

1. Build app's Docker image via **Execute-DockerBuild.ps1** script.
2. Run the app from a new container via **Execute-DockerRun.ps1** script.
