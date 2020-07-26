import json


def delete_file(filename):
    open(filename, "w").close()


def init():
    delete_file("output/Adress.sql")
    delete_file("output/Faculty.sql")
    delete_file("output/University.sql")


def main():
    address_list = []
    university_list = []
    faculty_list = []
    with open("university.json", encoding='utf-8') as data_file:
        universities = json.load(data_file)
        for university in universities:
            address_list.append(university["UniversityAddress"])

            university_list.append({
                "Id": university["Id"],
                "Name": university["Name"],
                "Email": university["Email"],
                "PhoneNumber": university["PhoneNumber"],
                "AddressId": university["UniversityAddress"]["Id"]
            })

            for faculty in university["Faculties"]:
                address_list.append(faculty["FacultyAddress"])

                faculty_list.append({
                    "Id": faculty["FacultyId"],
                    "Name": faculty["Name"],
                    "Email": faculty["Email"],
                    "PhoneNumber": faculty["PhoneNumber"],
                    "UniversityId": university["Id"],
                    "AddressId": faculty["FacultyAddress"]["Id"]
                })

    # filter duplicated id in addresses, faculties and unversities
    address_list = [dict_item for i, dict_item in enumerate(address_list)
                    if dict_item["Id"] not in [address["Id"] for address in address_list[i + 1:]]]
    faculty_list = [dict_item for i, dict_item in enumerate(faculty_list)
                    if dict_item["Id"] not in [faculty["Id"] for faculty in faculty_list[i + 1:]]]
    university_list = [dict_item for i, dict_item in enumerate(university_list)
                       if dict_item["Id"] not in [university["Id"] for university in university_list[i + 1:]]]

    print(address_list)
    print(faculty_list)
    print(university_list)
    address_string_builder_sql = "USE [Couponel]\nGO\n\n"
    for address in address_list:
        address_string_builder_sql += """INSERT INTO [dbo].[Addresses]
           ([Id]
           ,[Country]
           ,[City]
           ,[Street]
           ,[Number])
        VALUES
           ('{}'
           ,'{}'
           ,'{}'
           ,'{}'
           ,'{}')\n\n""".format(address["Id"],
                   address["Country"],
                   address["City"],
                   address["Street"],
                   address["Number"])

    address_string_builder_sql += "GO"
    # print(address_string_builder_sql)

    faculty_string_builder_sql = "USE [Couponel]\nGO\n\n"
    for faculty in faculty_list:
        faculty_string_builder_sql += """INSERT INTO [dbo].[Faculties]
           ([Id]
           ,[Name]
           ,[Email]
           ,[PhoneNumber]
           ,[UniversityId]
           ,[AddressId])
     VALUES
           ('{}'
           ,'{}'
           ,'{}'
           ,'{}'
           ,'{}'
           ,'{}')\n\n""".format(faculty["Id"],
                   faculty["Name"],
                   faculty["Email"],
                   faculty["PhoneNumber"],
                   faculty["UniversityId"],
                   faculty["AddressId"])

    faculty_string_builder_sql += "GO"
    # print(faculty_string_builder_sql)

    university_string_builder_sql = "USE [Couponel]\nGO\n\n"
    for university in university_list:
        university_string_builder_sql += """INSERT INTO [dbo].[Universities]
           ([Id]
           ,[Name]
           ,[Email]
           ,[PhoneNumber]
           ,[AddressId])
     VALUES
           ('{}'
           ,'{}'
           ,'{}' 
           ,'{}'
           ,'{}')\n\n""".format(university["Id"],
                   university["Name"],
                   university["Email"],
                   university["PhoneNumber"],
                   university["AddressId"])
    university_string_builder_sql += "GO"
    # print(university_string_builder_sql)

    with open("output/Address.sql", mode="w", encoding="utf-8") as address_file:
        address_file.write(address_string_builder_sql)
    with open("output/Faculty.sql", mode="w", encoding="utf-8") as faculty_file:
        faculty_file.write(faculty_string_builder_sql)
    with open("output/University.sql", mode="w", encoding="utf-8") as university_file:
        university_file.write(university_string_builder_sql)


if __name__ == '__main__':
    main()
