from os import read

myfile = open('D:\\_Google_Drive_\\_Sync_\\_Online_Seminars_\\Udemy\\2021 Complete Python Bootcamp From Zero to Hero in Python\\00-Python Object and Data Structure Basics\\test.txt')
print(myfile.read())
myfile.seek(0) #resets the stream to the start of the text file so that we are able to re-read it
print(myfile.readlines())
myfile.close() # close the file when we no longer need it 

# this way we no longer need to close the file 
# mode can change according to what we need to do with the file
with open('D:\\_Google_Drive_\\_Sync_\\_Online_Seminars_\\Udemy\\2021 Complete Python Bootcamp From Zero to Hero in Python\\00-Python Object and Data Structure Basics\\test.txt',mode='r') as my_new_file:
    contents = my_new_file.read()
    print(contents)

with open('D:\\_Google_Drive_\\_Sync_\\_Online_Seminars_\\Udemy\\2021 Complete Python Bootcamp From Zero to Hero in Python\\00-Python Object and Data Structure Basics\\test.txt',mode='a') as my_new_file:
    my_new_file.write('\nThird Line')
with open('D:\\_Google_Drive_\\_Sync_\\_Online_Seminars_\\Udemy\\2021 Complete Python Bootcamp From Zero to Hero in Python\\00-Python Object and Data Structure Basics\\test.txt',mode='r') as my_new_file:
    contents = my_new_file.read()
    print(contents)

    
with open('D:\\_Google_Drive_\\_Sync_\\_Online_Seminars_\\Udemy\\2021 Complete Python Bootcamp From Zero to Hero in Python\\00-Python Object and Data Structure Basics\\test.txt',mode='w') as my_new_file:
    my_new_file.write('First Line')
    my_new_file.write('\nSecond Line')
    my_new_file.write('\nThird Line')
with open('D:\\_Google_Drive_\\_Sync_\\_Online_Seminars_\\Udemy\\2021 Complete Python Bootcamp From Zero to Hero in Python\\00-Python Object and Data Structure Basics\\test.txt',mode='r') as my_new_file:
    contents = my_new_file.read()
    print(contents)