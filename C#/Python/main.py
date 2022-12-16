#   Реализация класса
class NumService():
    def __init__(self):
        self.numList = []

    #   Метод чтения файла. Сохраняет список в параметр numList
    def readFile(self, fileName: str) -> list[int]:
        with open('nums.txt', 'r') as file:
            self.numList = file.read().split(' ')       # Парсинг строки с разделителем
        self.numList = [int(x) for x in self.numList]   # Изменение типа элементов с str на int

    #   Метод нахождения мин и макс. Возвращает список list[minValue, maxValue]
    def get_min_max(self) -> list[int]:
        minValue = min(self.numList)
        maxValue = max(self.numList)

        """ Если подробно
        minValue = self.numList[0]
        maxValue = self.numList[0]

        for num in self.numList:
            if num < minValue: minValue = num
            if num > maxValue: maxValue = num
        """

        return [minValue, maxValue]

    #   Метод перемножения всех четных чисел.
    #   Возвращает результат int. Если четных нет, то возващает 0. Если четное только одно, то возвращает это же число
    def get_multi_even(self) -> int:
        result = 1

        for num in self.numList:
            num = int(num)

            if num % 2 == 0 and num != 0:
                result *= num

        if result != 1:
            return result
        else:
            return 0


#   Тестиование
service = NumService()
service.readFile('nums.txt')

#print(f"numList = {service.numList}")
print(f'Min/Max = {service.get_min_max()}')
print(f'MultiEven = {service.get_multi_even()}')