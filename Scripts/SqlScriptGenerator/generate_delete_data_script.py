def main():
    delete_data_query = "USE [Couponel] \nGO\n\n"
    delete_data_query += "DELETE FROM [dbo].[Faculties]\n"
    delete_data_query += "DELETE FROM [dbo].[Universities]\n"
    delete_data_query += "DELETE FROM [dbo].[Addresses]\n"
    delete_data_query += "DELETE FROM [dbo].[Offerers]\n"
    delete_data_query += "DELETE FROM [dbo].[Students]\n"
    delete_data_query += "DELETE FROM [dbo].[Admins]\n"
    delete_data_query += "DELETE FROM [dbo].[Users]\n\n"
    delete_data_query += "GO"

    with open("output/DeleteData.sql", mode="w", encoding="utf-8") as delete_data_file:
        delete_data_file.write(delete_data_query)


if __name__ == '__main__':
    main()
