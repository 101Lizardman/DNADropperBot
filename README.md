# MyDNA Life
#### Shane Vincent
#### vincent.shane101@gmail.com
#### https://github.com/101Lizardman

## The Application
The console application can be found in the DNADropperBot project directory.
```
cd DNADropperBot
```
The application can be executed by running `dotnet run <path-to-input-data>`

One argument is required, which is a path to a file containing input data for the application.

#### Assumptions / Notes
* Attempting to move outside of the 5x5 grid will instead just result in no change in position
* The robot will never run out of solution to pipette
* It was never really specified what the DETECT command really does. I decided that it should print to console.
* A well can never "overflow", if it is full and the DROP command is used on it, it just stays full.
* I found it a little strange how it was declared the North/South direction to be X and the East/West direction to be Y.
* It was specified that the robot "must be prevented from moving beyond the boundaries of the plate" but also declared elsewhere that the robot sometimes cannot detect the plate.
* The examples of outputs that were provided were not inherently true and were missing information. This was a little misleading.

## Tests
There is an NUnit testing project, found in the DNADropperTest directory.
```
cd DNADropperTest
```
These tests can be executed by running `dotnet test`
