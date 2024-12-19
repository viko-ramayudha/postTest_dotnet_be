public class JadwalPerawatan {
    public int id_jadwal_perawatan { get; set; }
    public int id_alat { get; set; }
    public int id_vendor { get; set; }
    public DateTime tanggal_perawatan { get; set; }
    public int qty { get; set; }
    public int total_harga { get; set; }
}