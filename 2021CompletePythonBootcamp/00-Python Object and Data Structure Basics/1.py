#print("hello \n world")
#print("hello \t world")
#print(len("hello"))

mystring = "Hello World"
print(mystring[0])
print(mystring[-2])

#slicing 
mystring = "abcdefghijk"
print(mystring[2:])
print(mystring[:3]) #go up to but not including 
print(mystring[3:6]) 
print(mystring[1:3]) 

#step slice 
print(mystring[::])
print(mystring[::3]) # go to jumbs of 2
print(mystring[::-1]) # reverse step , clever python trick to reverse string

print("Hello World"[8])
print("tinker"[1:4])


#concatenation 
name = 'Sam'
last_letters = name[1:]
name = 'P' + last_letters
print(name)
letter = 'z' 
print(letter * 10)

#string functions and methods 
x = 'Hi This is a a string'
print(x.upper())
print(x.lower())
print(x.split()) # split a string based on space or based on a letter we pass
print(x.split('i'))


#string print formatting 
print('This is a string {}'.format('INSERTED'))
print('The {} {} {}'.format('fox','brown','quick'))
print('The {2} {1} {0}'.format('fox','brown','quick'))
print('The {0} {0} {0}'.format('fox','brown','quick'))
print('The {q} {b} {f}'.format(f='fox',b='brown',q = 'quick'))

#float formatting 
result = 100/777 
print(result)
print("result: {}".format(result))
print("result: {r}".format(r = result))
print("result: {r:1.3f}".format(r = result))

print(type(result))

name = "Jose"

print(f'Hello, his name is {name}') # f-strings

age = 3 

print(f'{name} is {age} years old')

#Lists - ordered sequence of various object types 
mylist = ['one','two','three']
print(mylist[0])
print(mylist[1:])
another_list = ['four','five'] 
new_list = mylist + another_list
print(new_list) 
new_list[0] = 'ONE ALL CAPS' #lists are mutable 
print(new_list)
new_list.append('six') # place any item in the end of the list
print(new_list)
popped_item = new_list.pop() # remove item from the end of the list
print(new_list)
print(popped_item)
new_list.pop(0) # remove from specified index position
print(new_list)
new_list = ['a','e','x','b','c']
num_list = [4,1,8,3]
new_list.sort() #this happens in place , which means that it does not return ANYTHING
print(new_list)
num_list.reverse() #same as sort 
print(num_list)

#Dictionaries - UnOrdered Sequence of Key - Value Objects and cannot be sorted
my_dict = {'key1':'value1','key2':'value2'}
print(my_dict)
print(my_dict['key1'])
prices_lookup = {'apple':2.99,'orange':1.99,'milk':5.80}
print(prices_lookup['apple'])
d = {'k1':123,'k2':[0,1,2],'k3':{'insidekey':100}}
print(d['k1'])
print(d['k2'][2])
print(d['k3']['insidekey'])

d['k4'] = 300
print(d)

print(d.keys()) #print dictionary keys
print(d.values()) #print dictionary values 
print(d.items()) #print all dictionary values 

#Tuples - tuples are immutable , provides very convenient source for data integrity, it is used wen we do not want our returned objects to be reassigned
t = (1,2,3)
mylist = [1,2,3] 
print(len(t))
t = ('one',2,3)
print(t[0])
print(t[-1])
print(t.count('one')) # how many times this appears
print(t.index('one')) # first occurence 

#Sets - UnOrdered collection of unique elements, Every object exists only one time 
myset = set() 
myset.add(1)
print(myset)
myset.add(2)
print(myset)
myset.add(2) # 2 will not be added again, HashSet
print(myset)

mylist = [1,1,1,2,2,2,3,3,3]
print(set(mylist)) #converting list to set will remove the duplicate items






