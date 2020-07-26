def main():


    delete_institutions_query = "USE [Couponel] \nGO\n\n"
    delete_institutions_query += "DELETE FROM [dbo].[Faculties]\n"
    delete_institutions_query += "DELETE FROM [dbo].[Universities]\n"
    delete_institutions_query += "DELETE FROM [dbo].[Addresses]\n\n"
    delete_institutions_query += "GO"

    with open("output/DeleteInstitutions.sql", mode="w", encoding="utf-8") as delete_institutions_file:
        delete_institutions_file.write(delete_institutions_query)


if __name__ == '__main__':
    main()
