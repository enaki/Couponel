:: Delete existing scrips
echo Y | del SqlScripts\*
rmdir SqlScripts
mkdir SqlScripts

:: Run python scripts
cd SqlScriptGenerator
python generate_delete_data_script.py
python generate_insert_data_script.py
cd ..

:: Move generated python scripts to SqlScripts
copy SqlScriptGenerator\output\* SqlScripts\
echo Y | del SqlScriptGenerator\output\*

:: Run scripts in Microsoft SQL Server
sqlcmd -S localhost\SQLEXPRESS -i SqlScripts\DeleteData.sql
sqlcmd -S localhost\SQLEXPRESS -i SqlScripts\Address.sql
sqlcmd -S localhost\SQLEXPRESS -i SqlScripts\University.sql
sqlcmd -S localhost\SQLEXPRESS -i SqlScripts\Faculty.sql
sqlcmd -S localhost\SQLEXPRESS -i SqlScripts\User.sql
sqlcmd -S localhost\SQLEXPRESS -i SqlScripts\Admin.sql
sqlcmd -S localhost\SQLEXPRESS -i SqlScripts\Offerer.sql
sqlcmd -S localhost\SQLEXPRESS -i SqlScripts\Student.sql
sqlcmd -S localhost\SQLEXPRESS -i SqlScripts\Coupon.sql
sqlcmd -S localhost\SQLEXPRESS -i SqlScripts\Comment.sql
sqlcmd -S localhost\SQLEXPRESS -i SqlScripts\RedeemedCoupon.sql
