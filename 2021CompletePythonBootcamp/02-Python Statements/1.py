#if elif else 
hungry = True 
if hungry:
    print('Feed Me')
else:
    print('I am not hungry')

loc = 'Bank'
if loc == 'Auto Shop':
    print('Cars are cool')
elif loc == 'Bank':
    print('money is cool')
elif loc == 'Store':
    print('Welcome to the Store')
else:
    print('I do not know much')

#for loop 
mylist = [1,2,3,4,5,6,7,8,9,10]
for item in mylist:
    if(item%2 == 0):
        print('{i} is even'.format(i = item))
        print(f'{item} is even')

list_sum = 0
for num in mylist:
    list_sum = list_sum + num
    print(list_sum)
print(list_sum)

mystring = 'Hello World'
for letter in mystring:
    print(letter)

tup = (1,2,3)
for item in tup:
    print(item)

mynewlist = [(1,2),(3,4),(5,6),(7,8)]
for item in mynewlist:
    print(item)
for (a,b) in mynewlist: #tuple unpacking
    print(a)
    print(b)

d = {'k1':1,'k2':2,'k3':3}
for item in d:
    print(item)
for key,value in d:
    print(key)
    print(value)
for item in d.items():
    print(item)
for key in d.keys():
    print(key)
for val in d.values():
    print(val)

# While Loops
x = 6 
while x < 5: 
    print(f'current value is {x}')
    x += 1
else:
    print(f'{x} is not less than 5')

#pass, break, continue keywords for loops
newlist = [1,2,3]
for item in newlist:
    pass #do nothing at all , lot of times we keep it as placeholder so as not to get a syntax error

mystr = 'Sammy'
for letter in mystr:
    if letter == 'a':
        continue # continue to the next iteration
    if letter == 'y':
        break #exit the iteration
    print(letter)

# Other Useful Operators 
for num in range(10):
    print(num)

for num in range(3,10):
    print(num)

for num in range(0,10,2):
    print(num)

print(list(range(10))) # range is one of the generators, here we cast it to a list

index_count = 0

for letter in 'abcde':
    print('At index {ic} the letter is {l}'.format(ic = index_count, l = letter))

word = 'abcde'
for letter in word:
    print(word[index_count])
    index_count += 1

for index, letter in enumerate(word):
    print(f'{index}, {letter}')

mylist1 = [1,2,3,4]
mylist2 = ['a','b','c']
mylist3 = [100,200,300]
for item in zip(mylist1,mylist2):
    print(item)

print('a' in [1,2,3]) # in operator to check for something that exists in list, tuple , dicts 
print('a' in 'ab')
print('k1' in {'k1':1,'k2':2})

mylist4 = [10,20,30,40,5,6,7,8,9,10]
print(min(mylist4))
print(max(mylist4))

#Math Library 
from random import shuffle 
shuffle(mylist4)
print(mylist4)
shuffle(mylist4)
print(mylist4)

from random import randint
print(randint(0,100))

# result = input('Name? ')
# print(result)

# result = input('Number? ')
# print(float(result))

#List Comprehensions 
mystr = 'hello' 

mylist = []
for letter in mystr:
    mylist.append(letter)
print(mylist)

mylist = [letter for letter in mystr] #this is the way with list comprehension , so we avoid all the not necessary code
print(mylist)

mylist = [x for x in range(0,11)]
print(mylist)
mylist = [x**2 for x in range(0,11)]
print(mylist)
mylist = [x for x in range(0,11) if x%2 == 0]
print(mylist)

celsius = [0,10,20,34.5]
fahrenheit = [((9/5)*temp + 32) for temp in celsius]
print(fahrenheit)
