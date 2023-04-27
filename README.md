# Poppel

This is a project completed as part of a course in second year on systems development using C#. The goal of this project was to design, construct, test, and implement a segment of the Poppel Order Processing System, a system for managing customer orders and inventory. It was developed by Takunda and myself.

# Functionality

The following functionality is provided by the system:

1. Create a customer
2. Create a customer order for at least 3 products (including checking if customer is blacklisted and checking inventory)
   - Reserve inventory for the items
3. Cancel an item that is not invoiced yet
4. Generate a picking list to initiate delivery
5. Print a report to identify all expired products in inventory

# Installation
To run this project on your local machine, you will need to have Visual Studio installed. You can download it from the official Visual Studio website.

1. Clone the repository or download the ZIP file and extract it to a folder on your machine.
2. Open Visual Studio and select "Open a project or solution."
3. Navigate to the folder where you cloned or extracted the repository and select the solution file (.sln extension).
4. Build the solution by selecting "Build Solution" in the Build menu.

Now the system was made for use by admins only so when you get to the login page, you will need an admin credential to login. Check the LogInPassword document for admin credentials to use.

# Usage
To use this project, simply run it within Visual Studio. You can create customers, create orders, cancel items, generate picking lists, and print reports using the graphical user interface.

# Contributions
Contributions are welcome! Please submit a pull request or create an issue if you encounter any bugs or have suggestions for new features.
