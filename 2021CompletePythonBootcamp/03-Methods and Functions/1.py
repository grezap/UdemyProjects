#Methods -- builtin in python objects
mylist = [1,2,3]
mylist.insert(1,50)
print(mylist)

#Functions 

def say_hello():
    print('hello')
say_hello()

def say_hello(name):
    print(f'hello {name}')
say_hello('greg')

def say_hello(name = 'default'): #we can provide default values in arguments
    print(f'hello {name}')
say_hello()

def add_num(num1,num2):
    return num1 + num2
num = add_num(1,2)
print(num)

def check_even_list(num_list):
    even_numbers = []
    for num in num_list:
        if num % 2 == 0:
            even_numbers.append(num)
    return even_numbers

print(check_even_list([1,2,3]))

# *args => arguments and **kwargs => keyword arguments
def myfunc(*args): # *args allows us to treat the incoming arguments as a tuple of parameters, this way we can pass as many arguments as we need
    for item in args:
        print(item)
    return sum(args) * 0.05

def myfunc(**kwargs): # **kwrags is a dictionary of arguments
    if 'fruit' in kwargs:
        print ('fruit is {}'.format(kwargs['fruit']))
    else:
        print('Did Not Find Any fruit')

myfunc(fruit='apple',veggie = 'lettuce')



