## OrderFood
Aplikasi ini difungsikan untuk melayani pemesanan menu dan menghitung total harga yang dipesan oleh pembeli 

# Fungsi
- User dapat melihat daftar makanan yang ditawarkan
- User dapat memasukkan atau menghapus makanan pilihan ke dalam keranjang
- User dapat melihat subtotal makanan yang terdapat pada keranjang
- User dapat melihat daftar voucher yang ditawarkan
- User dapat menggunakan salah satu voucher
- User dapat melihat harga total termasuk potongannya
# Simulasi
- Simulasi 1
![Simulasi1](Simulasi1.png)
- Simulasi 2
![Simulasi2](Simulasi2.png)
- Simulasi 3
![Simulasi3](Simulasi3.png)

# Penjelasan 

`` 
private void generateContentPenawaran()
        {
            Item drink1 = new Item("Coffe Late", 30000);
            Item drink2 = new Item("BlackTea", 20000);
            Item food1 = new Item("Pizza", 75000);
            Item drink3 = new Item("Milk Shake", 15000);
            Item food2 = new Item("Fried Rice Special", 45000);
            Item drink4 = new Item("Watermelon Juice", 25000);
            Item drink5 = new Item("Lemon Squash", 30000);
            Penawarancontroller.addItem(drink1);
            Penawarancontroller.addItem(drink2);
            Penawarancontroller.addItem(food1);
            Penawarancontroller.addItem(drink3);
            Penawarancontroller.addItem(food2);
            Penawarancontroller.addItem(drink4);
            Penawarancontroller.addItem(drink5);
             listPenawaran.Items.Refresh();
        }
``

 Pada ``Penawaran.xaml.cs `` terdapat code seperti diatas yang berfungsi untuk membuat list item yang nanti akan ditambahkkan ke listbox.
Untuk menambahkan data ke listbox item dan voucher ke masing-masing listbox maka terdapat perintah  

`` listBoxPesanan.ItemsSource = controller.getSelectedItems();

   listBoxPakaiVoucher.ItemsSource = controller.getSelectedVouchers();``
   
pada `` MainWindow.xaml.cs``
untuk kode pengkontrolan dari keranjang belanja dilakukan oleh``MainWindoController.cs``
Didalam ``PilihVoucher.xaml.cs`` terdapat kode untuk membuat object voucher yang nantinya akan dimasukkan ke listbox
