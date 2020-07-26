def main():

    delete_address_query = "USE [Couponel] \nGO\n\n"
    delete_address_query += "DELETE FROM [dbo].[Addresses]\n\n"
    delete_address_query += "GO"

    delete_faculty_query = "USE [Couponel] \nGO\n\n"
    delete_faculty_query += "DELETE FROM [dbo].[Faculties]\n\n"
    delete_faculty_query += "GO"

    delete_university_query = "USE [Couponel] \nGO\n\n"
    delete_university_query += "DELETE FROM [dbo].[Universities]\n\n"
    delete_university_query += "GO"

    with open("output/DeleteAddress.sql", mode="w", encoding="utf-8") as delete_address_file:
        delete_address_file.write(delete_address_query)
    with open("output/DeleteFaculty.sql", mode="w", encoding="utf-8") as delete_faculty_file:
        delete_faculty_file.write(delete_faculty_query)
    with open("output/DeleteUniversity.sql", mode="w", encoding="utf-8") as delete_university_file:
        delete_university_file.write(delete_university_query)

if __name__ == '__main__':
    main()
