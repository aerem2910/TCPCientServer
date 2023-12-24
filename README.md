
**Программа представляет собой простой клиент-серверный пример, где клиент отправляет серверу строку с числами через запятую, сервер фильтрует четные числа из этой строки и отправляет результат обратно клиенту.**

**Сервер (Server.cs):**
**Main:** Создает TcpListener для прослушивания подключений на порту 8888. В бесконечном цикле принимает подключения и для каждого клиента создает новый поток для обработки.

**HandleClient:** Метод, выполняемый в отдельном потоке для обработки каждого клиента. Получает потоки для чтения и записи из TcpClient. Считывает строку с числами от клиента, фильтрует четные числа и отправляет результат обратно клиенту.

**Клиент (Client.cs):**
Main: Спрашивает пользователя о вводе чисел через запятую. Создает TcpClient для подключения к серверу (в данном случае, к localhost на порт 8888). Отправляет серверу введенные числа, затем получает отфильтрованные четные числа и выводит их на экран.
