using practicaLinq.Models;

namespace practicaLinq;

public class Program
{
    public static void Main(string[] args)
    {
    
        // coleccion students
        var students = new List<Student>
        {
            new Student { id = 1, name = "Diego Vallejo", age = 28 },
            new Student { id = 2, name = "Davis Zapata", age = 22 },
            new Student { id = 3, name = "John Willis", age = 20 },
            new Student { id = 4, name = "Edd Rave", age = 19 },
            new Student { id = 5, name = "Anne Wenzel", age = 31 },
            new Student { id = 6, name = "Klauss Stauffemberg", age = 32 },
        };
        
        
        // Colección de Courses:
        var courses = new List<Course>
        {
            new Course { id = 1, title = "Math", credits = 3 },
            new Course { id = 2, title = "Biology", credits = 3 },
            new Course { id = 3, title = "Calculus One", credits = 4 },
            new Course { id = 4, title = "Calculus Two", credits = 5 },
            new Course { id = 5, title = "Etics", credits = 2 },
            new Course { id = 6, title = "Physics", credits = 4 }
        };
        
        
        // Coleccion de Enrollments:
        var enrollments = new List<Enrollment>
        {
            new Enrollment { id = 1, studentId = 1, courseId = 2, grade = 80.1 },
            new Enrollment { id = 2, studentId = 2, courseId = 1, grade = 50.5 },
            new Enrollment { id = 3, studentId = 3, courseId = 4, grade = 78.3 },
            new Enrollment { id = 4, studentId = 3, courseId = 5, grade = 33.1 },
            new Enrollment { id = 5, studentId = 4, courseId = 5, grade = 20.9 },
            new Enrollment { id = 6, studentId = 5, courseId = 6, grade = 100.0 },
            new Enrollment { id = 7, studentId = 6, courseId = 3, grade = 97.5 }
        };
        
        
        // LINQ QUERIES:
        
        // Ejercicio 1: Filtrar estudiantes mayores de 20 años
        var query_E1 = from s in students
            where s.age > 20
            select s;
        foreach (var order in students)
        {
            Console.WriteLine($"La edad de {order.name} es {order.age}");
        }

        Console.WriteLine("--------------------------------------");


        // Ejercicio 2: Ordenar cursos por créditos
        var query_E2 = from c in courses
            orderby c.credits ascending 
            select c;
        Console.WriteLine("Los cursos ordenamos por créditos son:");
        foreach (var order in query_E2)
        {
            Console.WriteLine($"{order.title}: {order.credits}");
        }

        Console.WriteLine("--------------------------------------");



        // Ejercicio 3: Buscar un curso específico
        var query_E3 = from c in courses
            where c.title == "Math"
            select c;

        //Console.WriteLine($"La materia buscada es: {}");
        foreach (var order in query_E3)
        {
            Console.WriteLine($"La materia buscada es: {order.title}");
        }

        Console.WriteLine("--------------------------------------");
        
        


        // Ejercicio 4: Contar matrículas
        
        
        
        
        
        
        // Ejercicio 5: Join entre matrículas y estudiantes
        // Ejercicio 6: Join triple (estudiante + curso + matrícula)
        // Ejercicio 8: Validaciones con LINQ (All, Any, Contains)






    }
}