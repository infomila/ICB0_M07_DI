[ ... back  ](../README.md)

# Accés a dades

## Proveïdors SGBD suportats

* SQLite
* MySQL
* SQLServer
* Postgress

## SQLite

### Versió mínima del Windows Platform
    <TargetPlatformMinVersion>10.0.16299.0</TargetPlatformMinVersion>

![S Q Lite Min Ver](images/SQLite_min_ver.png)

### Nugets necesaris
![S Q Lite Nuggets](images/SQLite_nuggets.png)

| Nuget | Version |
|-----------|-------|
| Microsoft.EntityFrameworkCore | 2.0.1 |
| Microsoft.EntityFrameworkCore.Sqlite|2.0.1|
| Microsoft.NETCore.UniversalWindowsPlatform|6.1.5|

### Creació de base de dades
* Crear un arxiu amb sqlite3.exe
```
	> sqlite3.exe empresa.db
```
* Executar un script sql
```
	 sqlite3> .read guio.sql
```

* Copiar base de dades a _Assets_ del projecte

![S Q Lite Db Assets](images/SQLite_db_assets.png)

* Definir la Compile action

![S Q Lite Db Assets Properties](images/SQLite_db_assets_properties.png)

### Canvis a App.xaml.cs
```c#
       public App()
        {
            this.InitializeComponent();
            this.Suspending += OnSuspending;
            // Demanar la inicialització de la BD
            InicialitzaBDAsync();

        }

        private async System.Threading.Tasks.Task InicialitzaBDAsync()
        {
            // Assegureu-vos que:
            // a) l'arxiu està a Assets, i l'heu inclòs al projecte
            // b) a les propietats de l'arxius la "Acción de compilación" és "Contenido"

            try
            {
                string name = SQLiteDBContext.DB_FILENAME;
                var dbFolderAppData = ApplicationData.Current.LocalFolder;
                StorageFolder dbFolder = await dbFolderAppData.CreateFolderAsync(SQLiteDBContext.DB_PATH, CreationCollisionOption.OpenIfExists);
                StorageFile dbFile = null;
                try
                {
                    dbFile = await dbFolder.GetFileAsync(name);
                }
                catch (FileNotFoundException ex)
                {
                    // L'arxiu de base de dades no ha estat creat, i per tant cal copiar-lo
                    // des d'Assets
                    var uriArxiuBDAAssets = new Uri($"ms-appx:///Assets/{SQLiteDBContext.DB_PATH}/{name}");
                    StorageFile arxiuBDAssets = await StorageFile.GetFileFromApplicationUriAsync(uriArxiuBDAAssets);
                    dbFile = await arxiuBDAssets.CopyAsync(dbFolder, name, NameCollisionOption.FailIfExists);
                }
            }
            catch (Exception ex)
            {

            }

        }

```

### Creació d'un DBContext

```c#
    class SQLiteDBContext :  DbContext 
    {
        public static string DB_FILENAME { get { return "empresa.db"; } }
        public static string DB_PATH { get { return "db"; } }

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            //optionBuilder.UseSqlite("Filename=db/empresa.db");
            optionBuilder.UseSqlite($"Filename={DB_PATH}/{DB_FILENAME}");
        }
    }
```

### Fent consultes SELECT

```c#
       /// <summary>
        /// Funció que retorna un llistat de departaments
        /// </summary>
        /// <returns></returns>
        public static string GetDepts()
        {
            String resultat="";
            using(SQLiteDBContext context = new SQLiteDBContext())
            {
                using(var connexio = context.Database.GetDbConnection()) // <== NOTA IMPORTANT: requereix ==>using Microsoft.EntityFrameworkCore;
                {
                    // Obrir la connexió a la BD
                    connexio.Open();

                    // Crear una consulta SQL
                    using( var consulta = connexio.CreateCommand())
                    {
                        
                        // query SQL
                        consulta.CommandText = @"select *  
                                                from dept ";
                        var reader = consulta.ExecuteReader();
                        while(reader.Read()) // per cada Read() avancem una fila en els resultats de la consulta.
                        {
                            int dept_no = reader.GetInt32(reader.GetOrdinal("DEPT_NO"));
                            string dnom = reader.GetString(reader.GetOrdinal("DNOM"));
                            string loc = reader.GetString(reader.GetOrdinal("LOC"));

                            resultat = $"{dept_no} \t\t {dnom} \t\t {loc} \n";
                        }
                    }

                }
            }
            return resultat;

        }
```

### Execució de consultes de selecció que només retornen una fila i columna
El cas típic de les consultes "select count(*)..." o "select max(col)..."

```c#
            using (SQLiteDBContext context = new SQLiteDBContext())
            {
                using (var connexio = context.Database.GetDbConnection()) // <== NOTA IMPORTANT: requereix ==>using Microsoft.EntityFrameworkCore;
                {
                    // Obrir la connexió a la BD
                    connexio.Open();

                    // Crear una consulta SQL
                    using (var consulta = connexio.CreateCommand())
                    {

                        // query SQL
                        consulta.CommandText = @"select count(*)  
                                                from dept ";
                        return (Int64) consulta.ExecuteScalar();
                    }
                }
            }

```


### Execució de consultes de modificació (insert/update/delete)

```c#
            using (SQLiteDBContext context = new SQLiteDBContext())
            {
                using (var connexio = context.Database.GetDbConnection()) // <== NOTA IMPORTANT: requereix ==>using Microsoft.EntityFrameworkCore;
                {
                    // Obrir la connexió a la BD
                    connexio.Open();

                    // Crear una consulta SQL
                    using (var consulta = connexio.CreateCommand())
                    {

                        // query SQL
                        consulta.CommandText = @"insert into dept (dept_no, dnom, loc) values ( 50, 'Finances','Tarragona') ";
                        int filesInserides = consulta.ExecuteNonQuery();
                        if(filesInserides!=1)
                        {
                            throw new Exception("Departament no inserit");
                        }
                    }
                }
            }
```