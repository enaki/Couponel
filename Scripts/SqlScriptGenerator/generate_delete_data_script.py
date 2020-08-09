def main():
    delete_data_query = "USE [Couponel] \nGO\n\n"
    delete_data_query += "DELETE FROM [dbo].[Comments]\n"
    delete_data_query += "DELETE FROM [dbo].[Photos]\n"
    delete_data_query += "DELETE FROM [dbo].[RedeemedCoupons]\n"
    delete_data_query += "DELETE FROM [dbo].[Coupons]\n"

    delete_data_query += "DELETE FROM [dbo].[Students]\n"

    delete_data_query += "DELETE FROM [dbo].[Faculties]\n"
    delete_data_query += "DELETE FROM [dbo].[Universities]\n"

    delete_data_query += "DELETE FROM [dbo].[Users]\n\n"

    with open("output/DeleteData.sql", mode="w", encoding="utf-8") as delete_data_file:
        delete_data_file.write("USE [Couponel] \nGO\n\n" + delete_data_query + "GO")
    with open("output/AllInOne.sql", mode="w", encoding="utf-8") as all_in_one_file:
        all_in_one_file.write(delete_data_query)


if __name__ == '__main__':
    main()
