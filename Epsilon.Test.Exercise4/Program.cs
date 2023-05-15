using Epsilon.Test.Exercise4;

Employee employee = new Employee { Name = "Alkis Employee" };
Manager manager = new Manager { Name = "Alkis Manager" };

DisplayProperty display = new();
display.Display(employee);
display.Display(manager);