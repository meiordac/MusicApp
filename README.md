# MusicApp
# Descripción del problema

El objetivo es desarrollar un sitio que utilice la API de Metadata de Spotify [1] para descargar información sobre artistas y canciones, y mostrar ciertas estadísticas de esta información.

En particular, el usuario debe poder buscar un artista desde un campo de texto, del cual se guardará una lista de todos sus álbumes y los temas de cada álbum en la base de datos.

Además, se debe poder elegir uno de los artistas ya descargados, y mostrar en una lista todos sus álbumes, ordenados por año. Para cada álbum de la lista anterior se debe mostrar la popularidad promedio de sus pistas y el nombre y longitud de su pista más larga.

La integración con la base de datos se debe realizar utilizando Entity Framework, y puede utilizar el enfoque Code-First o Database-First, según prefiera. Las consultas a la base de datos se deben realizar mediante queries en LINQ.

# Requisitos No Funcionales

- Desarrolle su solución en el lenguaje C#
- La base de datos debe ser SQL Server, ya sea Express o LocalDB
- La interfaz gráfica debe ser un sitio Web Forms o ASP.NET MVC, según prefiera
- Puede utilizar las librerías externas que estime convenientes
- Debe subir el código a un repositorio en Github [2] con un README explicativo

[1] https://developer.spotify.com/technologies/metadata-api
[2] https://github.com

# Detalles de implementación
- Se usa ASP.net MVC
- Puede que sea necesario instalar SQLLocalDB desde el siguiente enlace: https://www.microsoft.com/en-us/download/confirmation.aspx?id=42299
- DB se resetea cada vez que se corre el app (por esto mismo se demora un poco en iniciar)
- Si se presiona ordenar por Released cambia el orden entre desc y asc
- Se usa nuget para manejar la metadata API, necesario ejecutar: Install-Package Zirpl.Spotify.MetadataApi
- Necesario instalar EF: Install-Package EntityFramework
