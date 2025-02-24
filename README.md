# Errors and Fixes in the Code

## Recursive Call Error in GetTxtFiles:

- Error: The recursive call inside the GetTxtFiles method was incorrectly referencing the same directory (directoryPath) instead of the subdirectory, leading to an infinite loop for subdirectories.
Fix: Changed the recursive call from GetTxtFiles(directoryPath, txtFiles); to GetTxtFiles(subdirectory, txtFiles);, allowing proper traversal of subdirectories.

## Improper StreamWriter Handling in AppendTextToFile:

- **Error**: The StreamWriter was not disposed of properly, which could lead to resource leaks. It was also manually initialized as null and used without proper disposal.
- **Fix**: Used a using statement for the StreamWriter, ensuring it is properly disposed of after writing to the file. This prevents resource leaks and improves file handling.

## Lack of Error Handling for Unauthorized Access and Other Exceptions:

- **Error**: The code did not handle potential errors like UnauthorizedAccessException (e.g., when trying to access protected directories) or general exceptions, which could cause the program to crash.
- **Fix**: Added try-catch blocks to handle specific exceptions:
  - UnauthorizedAccessException: Skipped directories with insufficient permissions.
  - Generic Exception: Displayed an error message if there were issues accessing a directory or file.

## Missing Console Feedback for File Writing Success or Failure:

- **Error**: There was no feedback or logging indicating whether text was successfully appended to the files.
- **Fix**: Added Console.WriteLine statements to log the success of the text appending process and error messages if the process failed.
