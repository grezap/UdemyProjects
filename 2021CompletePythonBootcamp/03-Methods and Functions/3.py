def myfunc(a):
    mystr=''
    for letter in a:
        if (a.index(letter) + 1) % 2 == 0:
            mystr = mystr + letter.upper()
        else:
            mystr = mystr + letter.lower()
    print(mystr)

myfunc('AdfGhSJ')
