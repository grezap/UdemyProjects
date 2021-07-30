def lesser_of_two_evens(a,b):
    if a % 2 == 0 and b % 2 == 0:
        if a > b:
            return b 
        else:
            return a 
    if a % 2 != 0 or b % 2 != 0:
        if a > b:
            return a 
        else:
            return b

result = lesser_of_two_evens(2,5)
#print(result)

def animal_crackers(text):
    words = text.split()
    first= words[0][0]
    second=words[1][0]
    if first == second:
        return True
    else:
        return False


#print(animal_crackers('test Test'))

def makes_twenty(n1,n2):
    if n1 + n2 == 20 or n1 == 20 or n2 == 20:
        return True 
    else:
        return False

#print(makes_twenty(10,20))

def old_macdonald(name):
    newname=name[0].upper() + name[1:3] + name[3].upper() + name[4:]
    return newname

#print(old_macdonald('macdonald'))

def master_yoda(text):
    words = text.split()
    words.reverse()
    sentence = ' '.join(words)
    return sentence

#print(master_yoda('we are good'))

def almost_there(n):
    if 90 <= n <= 110 or 190 <= n <= 210:
        return True 
    else:
        return False

# print(almost_there(90))
# print(almost_there(104))
# print(almost_there(150))
# print(almost_there(209))

def has_33(nums):
    for item in range(0, len(nums) - 1):
        if nums[item] == 3 and nums[item + 1] == 3:
            return True
    return False

#print(has_33([3,1,3, 3]))

def paper_doll(text):
    word=''
    for letter in text:
        word = word + (letter * 3)
    return word

print(paper_doll('Mississippi'))