import subprocess
import os

def EFCreateMigration():
    subprocess.run("dotnet ef migrations add InitDB", check=True)
    
def EFUpdateDB():
    subprocess.run("dotnet ef database update", check=True)

EFCreateMigration()
EFUpdateDB()