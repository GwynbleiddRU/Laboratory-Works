	Проект в архиве

	Постановка задачи:
1.	Создать иерархию классов (базовый  – производный) в соответствии с вариантом (см. лаб. раб. №10).
2.	В производном классе определить свойство, которое возвращает ссылку на объект базового класса (это свойство должно возвращать ссылку на объект  базового класса, а не ссылку на вызывающий объект производного класса). Например, для иерархии классов Person-Student в классе Student можно определить свойство
   public Person BasePerson
        {
            get
            {
                return new Person(name, age);
            }
        }
3.	Определить класс TestCollections, который содержит поля следующих типов 
	Коллекция_1<TKey> ; 
	Коллекция_1<string> ; 
	Коллекция_2<TKey, TValue> ; 
	Коллекция_2<string, TValue> . 
	где тип ключа TKey и тип значения TValue связаны отношением базовый-производный (см. задание 1), Коллекция_1 и Коллекция_2 – коллекции из пространства имен System.Collections.Generic.
4.	Написать конструктор класса TestCollections, в котором создаются коллекции с заданным числом элементов. 
5.	Для автоматической генерации элементов коллекций в классе TestCollections надо определить статический метод, который принимает один целочисленный параметр типа int и возвращает ссылку на объект производного типа (Student). Каждый объект (Student) содержит подобъект базового класса (Person). Соответствие между значениями целочисленного параметра метода и подобъектами Person класса Student должно быть взаимно-однозначным. 
6.	Все четыре коллекции должны содержать одинаковое число элементов. Каждому элементу из коллекции Коллекция_1<TKey> должен отвечать элемент в коллекции Коллекция_2<TKey, TValue> с равным значением ключа. Список Коллекция_1<string> состоит из строк, которые получены в результате вызова метода ToString() для объектов TKey из списка Коллекция_1<TKey>. Каждому элементу списка Коллекция_1<string> отвечает элемент в Коллекция_2 <string, TValue> с равным значением ключа типа string.
7.	Для четырех разных элементов – первого, центрального, последнего и элемента, не входящего в коллекцию – надо измерить время поиска элемента в коллекциях Коллекция_1<TKey> и Коллекция_1<string> с помощью метода Contains;  элемента по ключу в коллекциях Коллекция_2< TKey, TValue> и Коллекция_2 <string, TValue > с помощью метода ContainsKey; значения элемента в коллекции Коллекция_2< TKey, TValue > с помощью метода ContainsValue.  
8.	Предусмотреть методы для работы с TestCollections (добавление и удаление элементов).
9.	Предусмотреть собственные классы для обработки исключительных ситуаций и выполнить обработку исключений с помощью стандартных исключений, а также с помощью исключений, определенных программистом.  

Вариант:		Queue<T>	SortedDictionary <K,T>