using System.Data;
// using System.Drawing;
using MySql.Data.MySqlClient;
using Mysqlx.Connection;


public class DbManager {
    private readonly string connectionString;

    public DbManager(IConfiguration configuration)
    {
        connectionString = configuration.GetConnectionString("DefaultConnection");
    }

    // Method_Alat
    // GetAllAlat
    public List<Alat> GetAllAlat(){
        List<Alat> alatsList = new List<Alat>();
        try{
            using (MySqlConnection connection = new MySqlConnection(connectionString)){
                string query = "SELECT * FROM alat";
                MySqlCommand command = new MySqlCommand(query, connection);
                connection.Open();
                using (MySqlDataReader reader = command.ExecuteReader()){
                    while (reader.Read()){
                        Alat alats  = new Alat{
                            id_alat = Convert.ToInt32(reader["Id_alat"]),
                            nama_alat = reader["Nama_alat"].ToString(),
                            tipe_alat = reader["Tipe_alat"].ToString(),
                            tanggal_beli = Convert.ToDateTime(reader["Tanggal_beli"]),
                            jumlah_alat = Convert.ToInt32(reader["Jumlah_alat"]),
                            status_kondisi = reader["Status_kondisi"].ToString(),
                        };
                        alatsList.Add(alats);
                    }
                }
            }
        }
        catch (Exception ex){
            Console.WriteLine(ex.Message);
        }
        return alatsList;
    }

    //CreatAlat
    public int CreateAlat(Alat alats){
        using (MySqlConnection connection = new MySqlConnection(connectionString)){
            string query = "INSERT INTO alat (nama_alat, tipe_alat, tanggal_beli, jumlah_alat, status_kondisi) VALUES (@Nama_alat, @Tipe_alat, @Tanggal_beli, @Jumlah_alat, @Status_kondisi)";
            using (MySqlCommand command = new MySqlCommand(query, connection)){
                command.Parameters.AddWithValue("@Nama_alat", alats.nama_alat);
                command.Parameters.AddWithValue("@Tipe_alat", alats.tipe_alat);
                command.Parameters.AddWithValue("@Tanggal_beli", alats.tanggal_beli);
                command.Parameters.AddWithValue("@Jumlah_alat", alats.jumlah_alat);
                command.Parameters.AddWithValue("@Status_kondisi", alats.status_kondisi);

                connection.Open();
                return command.ExecuteNonQuery();
            }
        }
    }

    //UpdtAlat (hanya nama_alat)
    public int UpdtAlat(int id_alat, UpdtAlat alats){
        using (MySqlConnection connection = new MySqlConnection(connectionString)){
            string query = "UPDATE alat SET nama_alat = @Nama_alat WHERE id_alat = @Id_alat";
            using (MySqlCommand command = new MySqlCommand(query, connection)){
                command.Parameters.AddWithValue("@Nama_alat", alats.nama_alat);
                command.Parameters.AddWithValue("@Id_alat", id_alat);

                connection.Open();
                return command.ExecuteNonQuery();
            }
        }
    }

    //DeleteAlat
    public int DeleteAlat(int id_alat){
        using (MySqlConnection connection = new MySqlConnection(connectionString)){
            // Membuka koneksi
            connection.Open();
            // Menjalankan query UPDATE untuk mengubah status kondisi menjadi 0
            string query = "UPDATE alat SET status_kondisi = 0 WHERE id_alat = @Id_alat";
            using (MySqlCommand command = new MySqlCommand(query, connection)){
                command.Parameters.AddWithValue("@Id_alat", id_alat);

                // Mengeksekusi query dan mengembalikan jumlah baris yang terpengaruh
                return command.ExecuteNonQuery();
            }
        }
    }


    // Method_Vendor
    // GetAllVendor
    public List<Vendor> GetAllVendor(){
        List<Vendor> vendorsList = new List<Vendor>();
        try{
            using (MySqlConnection connection = new MySqlConnection(connectionString)){
                string query = "SELECT * FROM vendor";
                MySqlCommand command = new MySqlCommand(query, connection);
                connection.Open();
                using (MySqlDataReader reader = command.ExecuteReader()){
                    while (reader.Read()){
                        Vendor vendors  = new Vendor{
                            id_vendor = Convert.ToInt32(reader["Id_vendor"]),
                            nama_vendor = reader["Nama_vendor"].ToString(),
                            alamat = reader["Alamat"].ToString(),
                            kontak = reader["Kontak"].ToString(),
                            spesialis_perawatan = reader["Spesialis_perawatan"].ToString(),
                            harga_perawatan = reader["Harga_perawatan"].ToString()
                        };
                        vendorsList.Add(vendors);
                    }
                }
            }
        }
        catch (Exception ex){
            Console.WriteLine(ex.Message);
        }
        return vendorsList;
    }

    //CreateVendor
    public int CreateVendor(Vendor vendors){
        using (MySqlConnection connection = new MySqlConnection(connectionString)){
            string query = "INSERT INTO vendor (nama_vendor, alamat, kontak, spesialis_perawatan, harga_perawatan) VALUES (@Nama_vendor, @Alamat, @Kontak, @Spesialis_perawatan, @Harga_perawatan)";
            using (MySqlCommand command = new MySqlCommand(query, connection)){
                command.Parameters.AddWithValue("@Nama_vendor", vendors.nama_vendor);
                command.Parameters.AddWithValue("@Alamat", vendors.alamat);
                command.Parameters.AddWithValue("@Kontak", vendors.kontak);
                command.Parameters.AddWithValue("@Spesialis_perawatan", vendors.spesialis_perawatan);
                command.Parameters.AddWithValue("@Harga_perawatan", vendors.harga_perawatan);

                connection.Open();
                return command.ExecuteNonQuery();
            }
        }
    }

     //UpdateVendor
    public int UpdateVendor(int id_vendor, Vendor vendors){
        using (MySqlConnection connection = new MySqlConnection(connectionString)){
            string query = "UPDATE vendor SET nama_vendor = @Nama_vendor, alamat = @Alamat, kontak = @Kontak, spesialis_perawatan = @Spesialis_perawatan, harga_perawatan = @Harga_perawatan WHERE id_vendor = @Id_vendor";
            using (MySqlCommand command = new MySqlCommand(query, connection)){
                command.Parameters.AddWithValue("@Nama_vendor", vendors.nama_vendor);
                command.Parameters.AddWithValue("@Alamat", vendors.alamat);
                command.Parameters.AddWithValue("@Kontak", vendors.kontak);
                command.Parameters.AddWithValue("@Spesialis_perawatan", vendors.spesialis_perawatan);
                command.Parameters.AddWithValue("@Harga_perawatan", vendors.harga_perawatan);
                command.Parameters.AddWithValue("@Id_vendor", id_vendor);

                connection.Open();
                return command.ExecuteNonQuery();
            }
        }
    }

    //DeleteVendor
    public int DeleteVendor(string nama_vendor){
        using (MySqlConnection connection = new MySqlConnection(connectionString)){
            string query = "DELETE FROM vendor WHERE nama_vendor = @Nama_vendor";
            using (MySqlCommand command = new MySqlCommand(query, connection)){
                command.Parameters.AddWithValue("@Nama_vendor", nama_vendor);

                connection.Open();
                return command.ExecuteNonQuery();
            }
        }
    }


    // Method_JadwalPerawatan
    // GetAllJadwalPerawatan
    public List<JadwalPerawatan> GetAllJadwalPerawatan(){
        List<JadwalPerawatan> jadwalperawatansList = new List<JadwalPerawatan>();
        try{
            using (MySqlConnection connection = new MySqlConnection(connectionString)){
                string query = "SELECT * FROM jadwal_perawatan_alat";
                MySqlCommand command = new MySqlCommand(query, connection);
                connection.Open();
                using (MySqlDataReader reader = command.ExecuteReader()){
                    while (reader.Read()){
                        JadwalPerawatan jadwalperawatans  = new JadwalPerawatan{
                            id_jadwal_perawatan = Convert.ToInt32(reader["Id_jadwal_perawatan"]),
                            id_alat = Convert.ToInt32(reader["Id_alat"]),
                            id_vendor = Convert.ToInt32(reader["Id_vendor"]),
                            tanggal_perawatan = Convert.ToDateTime(reader["Tanggal_perawatan"]),
                            qty = Convert.ToInt32(reader["Qty"]),
                            total_harga = Convert.ToInt32(reader["Total_harga"])

                            // if (status_kondisi == 1) {
                            //     jadwalperawatans.StatusKondisiAlat = "Alat masih dalam kondisi baik";
                            // } else {
                            //     jadwalperawatans.StatusKondisiAlat = "Alat perlu diperbaiki";
                            // }

                            // Hitung total harga berdasarkan jumlah alat yang diperbaiki
                            // if (jadwalPerawatan.StatusKondisiAlat.equals("Alat perlu diperbaiki")) {
                            //     jadwalperawatans.total_harga = jadwalPerawatan.Qty * GetHargaPerawatan(jadwalPerawatan.IdVendor);
                            // }
                        };
                        jadwalperawatansList.Add(jadwalperawatans);
                    }
                }
            }
        }
        catch (Exception ex){
            Console.WriteLine(ex.Message);
        }
        return jadwalperawatansList;
    }

    //GetByTipeAlat
    public List<GetByTipeAlat> GetByTipeAlat(string tipe_alat)
    {
        List<GetByTipeAlat> getbytipealatsList = new List<GetByTipeAlat>();
        try
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT tipe_alat, nama_alat, status_kondisi FROM alat WHERE tipe_alat = @Tipe_alat";
                MySqlCommand command = new MySqlCommand(query, connection);
                connection.Open();
                command.Parameters.AddWithValue("@Tipe_alat", tipe_alat);
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        GetByTipeAlat getbytipealats = new GetByTipeAlat
                        {
                            tipe_alat = reader["Tipe_alat"].ToString(),
                            nama_alat = reader["Nama_alat"].ToString(),
                            status_kondisi = reader["Status_kondisi"].ToString()
                        };
                        getbytipealatsList.Add(getbytipealats);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        return getbytipealatsList;
    }


    // Jadwal_Perawatan
    public List<JadwalPerawatan> GetDataJadwal()
    {
        List<JadwalPerawatan> ListJadwal = new List<JadwalPerawatan>();
        try
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT * FROM Jadwal_Perawatan_Alat";
                MySqlCommand command = new MySqlCommand(query, connection);
                connection.Open();
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        JadwalPerawatan jadwal = new JadwalPerawatan
                        {
                            id_jadwal_perawatan = Convert.ToInt32(reader["Id_Jadwal_Perawatan"]),
                            id_alat = Convert.ToInt32(reader["Id_Alat"]),
                            id_vendor = Convert.ToInt32(reader["Id_Vendor"]),
                            tanggal_perawatan = Convert.ToDateTime(reader["Tanggal_Perawatan"]),
                            qty = Convert.ToInt32(reader["Qty"]),
                            total_harga = Convert.ToInt32(reader["Total_Harga"])
                        };
                        ListJadwal.Add(jadwal);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        return ListJadwal;
    }

    public string CreateDataJadwal(JadwalPerawatan jadwal)
    {
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            connection.Open();

            // Deklarasi data tabel alat yang terhubung dengan data jadwal sesuai id_alat
            Alat alat = null;
            string queryDataAlat = "SELECT * FROM alat WHERE id_alat = @Id_Alat";
            using (var dataAlat = new MySqlCommand(queryDataAlat, connection))
            {
                dataAlat.Parameters.AddWithValue("@Id_Alat", jadwal.id_alat);
                
                using (var reader = dataAlat.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        alat = new Alat
                        {
                            id_alat = Convert.ToInt32(reader["Id_Alat"]),
                            jumlah_alat = Convert.ToInt32(reader["Jumlah_Alat"]),
                            nama_alat = reader["Nama_Alat"].ToString(),
                            status_kondisi = reader["Status_Kondisi"].ToString(),
                            tanggal_beli = Convert.ToDateTime(reader["Tanggal_Beli"]),
                            tipe_alat = reader["Tipe_Alat"].ToString(),
                        };
                    }
                }
            }

            // Deklarasi data tabel vendor yang terhubung dengan data jadwal sesuai id_vendor
            Vendor vendor = null;
            string queryDataVendor = "SELECT * FROM vendor WHERE id_vendor = @Id_Vendor";
            using (var dataVendor = new MySqlCommand(queryDataVendor, connection))
            {
                dataVendor.Parameters.AddWithValue("@Id_Vendor", jadwal.id_vendor);
                
                using (var reader = dataVendor.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        vendor = new Vendor
                        {
                            id_vendor = Convert.ToInt32(reader["Id_Vendor"]),
                            nama_vendor = reader["Nama_Vendor"].ToString(),
                            alamat = reader["Alamat"].ToString(),
                            kontak = reader["Kontak"].ToString(),
                            spesialis_perawatan = reader["Spesialis_Perawatan"].ToString(),
                            harga_perawatan = reader["Harga_Perawatan"].ToString(),
                        };
                    }
                }
            }

            if (alat == null)
            {
                return "Alat tidak ada";
            }

            if (vendor == null)
            {
                return "Vendor tidak ada";
            }

            if (alat.status_kondisi == "1")
            {
                return "Alat masih berfungsi dengan baik";
            }
            else if (alat.status_kondisi == "-1")
            {
                var total_harga = jadwal.qty * Convert.ToInt32(vendor.harga_perawatan);

                string queryInsertJadwal = "INSERT INTO Jadwal_Perawatan_Alat (id_alat, id_vendor, tanggal_perawatan, qty, total_harga) VALUES (@Id_Alat, @Id_Vendor, @Tanggal_Perawatan, @Qty, @Total_Harga)";
                using (MySqlCommand command = new MySqlCommand(queryInsertJadwal, connection))
                {
                    command.Parameters.AddWithValue("@Id_Alat", jadwal.id_alat);
                    command.Parameters.AddWithValue("@Id_Vendor", vendor.id_vendor);
                    command.Parameters.AddWithValue("@Tanggal_Perawatan", jadwal.tanggal_perawatan);
                    command.Parameters.AddWithValue("@Qty", jadwal.qty);
                    command.Parameters.AddWithValue("@Total_Harga", total_harga);

                    command.Parameters["@Tanggal_Perawatan"].MySqlDbType = MySqlDbType.Date;

                    int result = command.ExecuteNonQuery();

                    if (result > 0)
                    {
                        string queryUpdateAlat = "UPDATE Alat SET status_kondisi = '1' WHERE id_alat = @Id_Alat";
                        using (MySqlCommand updateCommand = new MySqlCommand(queryUpdateAlat, connection))
                        {
                            updateCommand.Parameters.AddWithValue("@Id_Alat", jadwal.id_alat);
                            updateCommand.ExecuteNonQuery();
                        }
                    }

                    return result > 0 ? "Data jadwal perawatan berhasil ditambahkan" : "Gagal menambahkan data jadwal perawatan";
                }
            }

            return "Status kondisi alat tidak valid";
        }
    }

    // Laporan
    public List<Laporan> GetDataLaporan()
    {
        List<Laporan> ListLaporan = new List<Laporan>();
        try
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "select alat.nama_alat, jadwal_perawatan_alat.qty, jadwal_perawatan_alat.total_harga from alat join jadwal_perawatan_alat on jadwal_perawatan_alat.id_alat = alat.id_alat order by tanggal_perawatan";
                MySqlCommand command = new MySqlCommand(query, connection);
                connection.Open();
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Laporan report = new Laporan
                        {
                            nama_alat = reader["Nama_Alat"].ToString(),
                            qty = Convert.ToInt32(reader["Qty"]),
                            total_harga = Convert.ToInt32(reader["Total_Harga"])
                        };
                        ListLaporan.Add(report);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        return ListLaporan;
    }

}