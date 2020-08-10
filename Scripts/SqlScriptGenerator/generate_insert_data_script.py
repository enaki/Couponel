import datetime
import json


def delete_file(filename):
    open(filename, "w").close()


def initialize(filename):
    with open(filename, encoding="utf-8", mode="w") as file:
        file.write("USE[Couponel]\nGO\n\n")


def finalize(filename):
    with open(filename, encoding="utf-8", mode="a") as file:
        file.write("GO\n")


def init():
    initialize("output/Faculty.sql")
    initialize("output/University.sql")

    initialize("output/Student.sql")
    initialize("output/User.sql")

    initialize("output/Coupon.sql")
    initialize("output/Comment.sql")
    initialize("output/RedeemedCoupon.sql")


def finish():
    finalize("output/Faculty.sql")
    finalize("output/University.sql")

    finalize("output/Student.sql")
    finalize("output/User.sql")

    finalize("output/Coupon.sql")
    finalize("output/Comment.sql")
    finalize("output/RedeemedCoupon.sql")

    finalize("output/AllInOne.sql")


def generate_institutions():
    university_list = []
    faculty_list = []
    with open("data/university.json", encoding='utf-8') as data_file:
        universities = json.load(data_file)
        for university in universities:

            university_list.append({
                "Id": university["Id"],
                "Name": university["Name"],
                "Email": university["Email"],
                "PhoneNumber": university["PhoneNumber"],
                "Country": university["UniversityAddress"]["Country"],
                "City": university["UniversityAddress"]["City"],
                "Street": university["UniversityAddress"]["Street"],
                "Number": university["UniversityAddress"]["Number"],
            })

            for faculty in university["Faculties"]:
                faculty_list.append({
                    "Id": faculty["FacultyId"],
                    "Name": faculty["Name"],
                    "Email": faculty["Email"],
                    "PhoneNumber": faculty["PhoneNumber"],
                    "UniversityId": university["Id"],
                    "Country": faculty["FacultyAddress"]["Country"],
                    "City": faculty["FacultyAddress"]["City"],
                    "Street": faculty["FacultyAddress"]["Street"],
                    "Number": faculty["FacultyAddress"]["Number"],
                })

    # filter duplicated id in addresses, faculties and unversities
    faculty_list = [dict_item for i, dict_item in enumerate(faculty_list)
                    if dict_item["Id"] not in [faculty["Id"] for faculty in faculty_list[i + 1:]]]
    university_list = [dict_item for i, dict_item in enumerate(university_list)
                       if dict_item["Id"] not in [university["Id"] for university in university_list[i + 1:]]]

    print(faculty_list)
    print(university_list)

    faculty_string_builder_sql = ""
    for faculty in faculty_list:
        faculty_string_builder_sql += """INSERT INTO [dbo].[Faculties]
           ([Id]
           ,[Name]
           ,[Email]
           ,[PhoneNumber]
           ,[UniversityId]
           ,[Country]
           ,[City]
           ,[Street]
           ,[Number])
     VALUES
           (CONVERT(uniqueidentifier,'{}')
           ,N'{}'
           ,N'{}'
           ,N'{}'
           ,CONVERT(uniqueidentifier,'{}')
           ,N'{}'
           ,N'{}'
           ,N'{}'
           ,N'{}')\n\n""".format(faculty["Id"],
                                 faculty["Name"],
                                 faculty["Email"],
                                 faculty["PhoneNumber"],
                                 faculty["UniversityId"],
                                 faculty["Country"],
                                 faculty["City"],
                                 faculty["Street"],
                                 faculty["Number"])

    # print(faculty_string_builder_sql)
    university_string_builder_sql = ""
    for university in university_list:
        university_string_builder_sql += """INSERT INTO [dbo].[Universities]
           ([Id]
           ,[Name]
           ,[Email]
           ,[PhoneNumber]
           ,[Country]
           ,[City]
           ,[Street]
           ,[Number])
     VALUES
           (CONVERT(uniqueidentifier,'{}')
           ,N'{}'
           ,N'{}' 
           ,N'{}'
           ,N'{}'
           ,N'{}'
           ,N'{}'
           ,N'{}')\n\n""".format(university["Id"],
                                 university["Name"],
                                 university["Email"],
                                 university["PhoneNumber"],
                                 university["Country"],
                                 university["City"],
                                 university["Street"],
                                 university["Number"])
    # print(university_string_builder_sql)

    with open("output/Faculty.sql", mode="a", encoding="utf-8") as faculty_file:
        faculty_file.write(faculty_string_builder_sql)
    with open("output/University.sql", mode="a", encoding="utf-8") as university_file:
        university_file.write(university_string_builder_sql)
    with open("output/AllInOne.sql", mode="a", encoding="utf-8") as all_in_one_file:
        all_in_one_file.write("\n\n{}\n\n{}".format(university_string_builder_sql,
                                                    faculty_string_builder_sql))


def generate_admins():
    user_list = []
    with open("data/admin.json", encoding='utf-8') as data_file:
        admins = json.load(data_file)
        for admin in admins:
            role = "Student" if admin["Account"]["Role"] == "student" else "Offerer" if admin["Account"]["Role"] == "offerer" else "Admin"
            user_list.append({
                "Id": admin["Id"],
                "Username": admin["Account"]["UserName"],
                "Email": admin["Account"]["Email"],
                "PasswordHash": admin["Account"]["PasswordHash"],
                "Role": role,
                "FirstName": admin["FirstName"],
                "LastName": admin["LastName"],
                "PhoneNumber": admin["PhoneNumber"],
                "Country": admin["Address"]["Country"],
                "City": admin["Address"]["City"],
                "Street": admin["Address"]["Street"],
                "Number": admin["Address"]["Number"],
            })

    # filter duplicated id in addresses, users and admins
    user_list = [dict_item for i, dict_item in enumerate(user_list)
                 if dict_item["Id"] not in [user["Id"] for user in user_list[i + 1:]]]

    print(user_list)

    user_string_builder_sql = get_user_string_builder(user_list)

    with open("output/User.sql", mode="a", encoding="utf-8") as user_file:
        user_file.write(user_string_builder_sql)
    with open("output/AllInOne.sql", mode="a", encoding="utf-8") as all_in_one_file:
        all_in_one_file.write("\n\n{}".format(user_string_builder_sql))


def generate_offerers():
    user_list = []

    with open("data/offerer.json", encoding='utf-8') as data_file:
        offerers = json.load(data_file)
        for offerer in offerers:
            user_list.append({
                    "Id": offerer["Id"],
                    "Username": offerer["Account"]["UserName"],
                    "Email": offerer["Account"]["Email"],
                    "PasswordHash": offerer["Account"]["PasswordHash"],
                    "Role": offerer["Account"]["Role"].capitalize(),
                    "FirstName": offerer["FirstName"],
                    "LastName": offerer["LastName"],
                    "PhoneNumber": offerer["PhoneNumber"],
                    "Country": offerer["Address"]["Country"],
                    "City": offerer["Address"]["City"],
                    "Street": offerer["Address"]["Street"],
                    "Number": offerer["Address"]["Number"],
                })

    # filter duplicated id in addresses, users and offerers
    user_list = [dict_item for i, dict_item in enumerate(user_list)
                 if dict_item["Id"] not in [user["Id"] for user in user_list[i + 1:]]]

    print(user_list)

    user_string_builder_sql = get_user_string_builder(user_list)

    with open("output/User.sql", mode="a", encoding="utf-8") as user_file:
        user_file.write(user_string_builder_sql)

    with open("output/AllInOne.sql", mode="a", encoding="utf-8") as all_in_one_file:
        all_in_one_file.write("\n\n{}".format(user_string_builder_sql))


def generate_students():
    student_list = []
    user_list = []
    with open("data/student.json", encoding='utf-8') as data_file:
        students = json.load(data_file)
        for student in students:
            user_list.append({
                "Id": student["Id"],
                "Username": student["Account"]["UserName"],
                "Email": student["Account"]["Email"],
                "PasswordHash": student["Account"]["PasswordHash"],
                "Role": student["Account"]["Role"].capitalize(),
                "FirstName": student["FirstName"],
                "LastName": student["LastName"],
                "PhoneNumber": student["PhoneNumber"],
                "Country": student["Address"]["Country"],
                "City": student["Address"]["City"],
                "Street": student["Address"]["Street"],
                "Number": student["Address"]["Number"],
            })
            student_list.append({
                "Id": student["Id"],
                "FacultyId": student["FacultyId"]
            })

    # filter duplicated id in addresses, users and students
    user_list = [dict_item for i, dict_item in enumerate(user_list)
                 if dict_item["Id"] not in [user["Id"] for user in user_list[i + 1:]]]

    print(user_list)
    user_string_builder_sql = get_user_string_builder(user_list)

    student_string_builder_sql = ""
    for student in student_list:
        student_string_builder_sql += """INSERT INTO [dbo].[Students]
                   ([Id]
                   ,[FacultyId])
             VALUES
                   (CONVERT(uniqueidentifier,'{}'),
                   CONVERT(uniqueidentifier,'{}'))\n\n""".format(student["Id"],
                                                                student["FacultyId"])
    with open("output/User.sql", mode="a", encoding="utf-8") as user_file:
        user_file.write(user_string_builder_sql)
    with open("output/Student.sql", mode="a", encoding="utf-8") as student_file:
        student_file.write(student_string_builder_sql)
    with open("output/AllInOne.sql", mode="a", encoding="utf-8") as all_in_one_file:
        all_in_one_file.write("\n\n{}\n\n{}".format(user_string_builder_sql,
                                                          student_string_builder_sql))


def get_user_string_builder(user_list):
    user_string_builder_sql = ""
    for user in user_list:
        user_string_builder_sql += """INSERT INTO [dbo].[Users]
           ([Id]
           ,[UserName]
           ,[Email]
           ,[PasswordHash]
           ,[Role]
           ,[FirstName]
           ,[LastName]
           ,[PhoneNumber]
           ,[Country]
           ,[City]
           ,[Street]
           ,[Number])
     VALUES
           (CONVERT(uniqueidentifier,'{}')
           ,N'{}'
           ,N'{}'
           ,N'{}'
           ,N'{}'
           ,N'{}'
           ,N'{}'
           ,N'{}'
           ,N'{}'
           ,N'{}'
           ,N'{}'
           ,N'{}')\n\n""".format(user["Id"],
                                 user["Username"],
                                 user["Email"],
                                 user["PasswordHash"],
                                 user["Role"],
                                 user["FirstName"],
                                 user["LastName"],
                                 user["PhoneNumber"],
                                 user["Country"],
                                 user["City"],
                                 user["Street"],
                                 user["Number"])
    return user_string_builder_sql


def generate_coupons():
    coupon_list = []

    with open("data/coupon.json", encoding='utf-8') as data_file:
        coupons = json.load(data_file)
        for coupon in coupons:
            coupon_list.append({
                "Id": coupon["Id"],
                "Name": coupon["Name"],
                "Category": coupon["Category"],
                "DateAdded": coupon["DateAdded"],
                "ExpirationDate": coupon["ExpirationDate"],
                "Description": coupon["Description"],
                "OffererId": coupon["OffererId"]
            })

    # filter duplicated id in coupons
    coupon_list = [dict_item for i, dict_item in enumerate(coupon_list)
                   if dict_item["Id"] not in [coupon["Id"] for coupon in coupon_list[i + 1:]]]

    print(coupon_list)
    coupon_string_builder_sql = ""
    for coupon in coupon_list:
        coupon_string_builder_sql += """INSERT INTO [dbo].[Coupons]
               ([Id]
               ,[Name]
               ,[Category]
               ,[DateAdded]
               ,[ExpirationDate]
               ,[Description]
               ,[UserId])
            VALUES
               (CONVERT(uniqueidentifier,'{}')
               ,N'{}'
               ,N'{}'
               ,N'{}'
               ,N'{}'
               ,N'{}'
               ,N'{}')\n\n""".format(coupon["Id"],
                                     coupon["Name"],
                                     coupon["Category"],
                                     coupon["DateAdded"],
                                     coupon["ExpirationDate"],
                                     coupon["Description"],
                                     coupon["OffererId"])

    with open("output/Coupon.sql", mode="a", encoding="utf-8") as coupon_file:
        coupon_file.write(coupon_string_builder_sql)
    with open("output/AllInOne.sql", mode="a", encoding="utf-8") as all_in_one_file:
        all_in_one_file.write("\n\n{}".format(coupon_string_builder_sql))


def generate_comments():
    comment_list = []

    with open("data/comment.json", encoding='utf-8') as data_file:
        comments = json.load(data_file)
        for comment in comments:
            comment_list.append({
                "Id": comment["Id"],
                "Content": comment["Content"],
                "DateAdded": datetime.datetime.now().strftime("%Y-%m-%d %H:%M:%S"),
                "UserId": comment["UserId"],
                "CouponId": comment["CouponId"]
            })

    # filter duplicated id in comments
    coupon_list = [dict_item for i, dict_item in enumerate(comment_list)
                   if dict_item["Id"] not in [coupon["Id"] for coupon in comment_list[i + 1:]]]

    print(comment_list)
    comment_string_builder_sql = ""
    for comment in comment_list:
        comment_string_builder_sql += """INSERT INTO [dbo].[Comments]
               ([Id]
               ,[Content]
               ,[DateAdded]
               ,[UserId]
               ,[CouponId])
            VALUES
               (CONVERT(uniqueidentifier,'{}')
               ,'{}'
               ,'{}'
               ,CONVERT(uniqueidentifier,'{}')
               ,CONVERT (uniqueidentifier,'{}'))\n\n""".format(comment["Id"],
                                                                 comment["Content"],
                                                                 comment["DateAdded"],
                                                                 comment["UserId"],
                                                                 comment["CouponId"])

    with open("output/Comment.sql", mode="a", encoding="utf-8") as comment_file:
        comment_file.write(comment_string_builder_sql)
    with open("output/AllInOne.sql", mode="a", encoding="utf-8") as all_in_one_file:
        all_in_one_file.write("\n\n{}".format(comment_string_builder_sql))


def generate_redeemedcoupons():
    redeemedcoupons_list = []

    with open("data/redeemedcoupon.json", encoding='utf-8') as data_file:
        redeemedcoupons = json.load(data_file)
        for reedemedcoupon in redeemedcoupons:
            redeemedcoupons_list.append({
                "Id": reedemedcoupon["Id"],
                "RedeemedDate": reedemedcoupon["RedeemedDate"],
                "Status": reedemedcoupon["Status"],
                "CouponId": reedemedcoupon["CouponId"],
                "StudentId": reedemedcoupon["StudentId"]
            })

    # filter duplicated id in comments
    coupon_list = [dict_item for i, dict_item in enumerate(redeemedcoupons_list)
                   if dict_item["Id"] not in [redeemedcoupon["Id"] for redeemedcoupon in redeemedcoupons_list[i + 1:]]]

    print(redeemedcoupons_list)
    redeemedcoupons_string_builder_sql = ""
    for redeemedcoupon in redeemedcoupons_list:
        redeemedcoupons_string_builder_sql += """INSERT INTO [dbo].[RedeemedCoupons]
               ([Id]
               ,[RedeemedDate]
               ,[Status]
               ,[CouponId]
               ,[StudentId])
            VALUES
               (CONVERT(uniqueidentifier,'{}')
               ,N'{}'
               ,N'{}'
               ,(CONVERT(uniqueidentifier,'{}'))
               ,(CONVERT (uniqueidentifier,'{}')))\n\n""".format(redeemedcoupon["Id"],
                                                                 redeemedcoupon["RedeemedDate"],
                                                                 redeemedcoupon["Status"],
                                                                 redeemedcoupon["CouponId"],
                                                                 redeemedcoupon["StudentId"])

    with open("output/RedeemedCoupon.sql", mode="a", encoding="utf-8") as redeemedcoupon_file:
        redeemedcoupon_file.write(redeemedcoupons_string_builder_sql)
    with open("output/AllInOne.sql", mode="a", encoding="utf-8") as all_in_one_file:
        all_in_one_file.write("\n\n{}".format(redeemedcoupons_string_builder_sql))


if __name__ == '__main__':
    init()
    generate_institutions()
    generate_admins()
    generate_offerers()
    generate_students()
    generate_coupons()
    generate_comments()
    generate_redeemedcoupons()
    finish()
