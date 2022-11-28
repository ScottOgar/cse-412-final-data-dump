using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Npgsql;

namespace CSE412_Final_Database
{
    public partial class Form1 : Form
    {
        List<int> chartList1 = new List<int>();
        List<int> chartList2 = new List<int>();
        Series series1 = new Series();

        public Form1()
        {
            InitializeComponent();
            this.Text = "Final Database Project";
        }

        private void ShowEarnsTable(object sender, EventArgs e)
        {
            NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;Port=5432;Database=final;User Id=postgres;Password=P0stgre5ql;");
            conn.Open();
            NpgsqlCommand comm = new NpgsqlCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = "select * from earns";
            NpgsqlDataReader dr = comm.ExecuteReader();
            if (dr.HasRows)
            {
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource = dt;
            }
            comm.Dispose();
            conn.Close();
        }

        private void ShowGameTable(object sender, EventArgs e)
        {
            NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;Port=5432;Database=final;User Id=postgres;Password=P0stgre5ql;");
            conn.Open();
            NpgsqlCommand comm = new NpgsqlCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = "select * from game";
            NpgsqlDataReader dr = comm.ExecuteReader();
            if (dr.HasRows)
            {
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource = dt;
            }
            comm.Dispose();
            conn.Close();
        }

        private void ShowPublisherTable(object sender, EventArgs e)
        {
            NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;Port=5432;Database=final;User Id=postgres;Password=P0stgre5ql;");
            conn.Open();
            NpgsqlCommand comm = new NpgsqlCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = "select * from publisher";
            NpgsqlDataReader dr = comm.ExecuteReader();
            if (dr.HasRows)
            {
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource = dt;
            }
            comm.Dispose();
            conn.Close();
        }

        private void ShowPublishesTable(object sender, EventArgs e)
        {
            NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;Port=5432;Database=final;User Id=postgres;Password=P0stgre5ql;");
            conn.Open();
            NpgsqlCommand comm = new NpgsqlCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = "select * from publishes";
            NpgsqlDataReader dr = comm.ExecuteReader();
            if (dr.HasRows)
            {
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource = dt;
            }
            comm.Dispose();
            conn.Close();
        }

        private void ShowSalesTable(object sender, EventArgs e)
        {
            NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;Port=5432;Database=final;User Id=postgres;Password=P0stgre5ql;");
            conn.Open();
            NpgsqlCommand comm = new NpgsqlCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = "select * from sales";
            NpgsqlDataReader dr = comm.ExecuteReader();
            if (dr.HasRows)
            {
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource = dt;
            }
            comm.Dispose();
            conn.Close();
        }

        private void ShowScoreTable(object sender, EventArgs e)
        {
            NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;Port=5432;Database=final;User Id=postgres;Password=P0stgre5ql;");
            conn.Open();
            NpgsqlCommand comm = new NpgsqlCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = "select * from score";
            NpgsqlDataReader dr = comm.ExecuteReader();
            if (dr.HasRows)
            {
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource = dt;
            }
            comm.Dispose();
            conn.Close();
        }

        private void ShowScoresTable(object sender, EventArgs e)
        {
            NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;Port=5432;Database=final;User Id=postgres;Password=P0stgre5ql;");
            conn.Open();
            NpgsqlCommand comm = new NpgsqlCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = "select * from scores";
            NpgsqlDataReader dr = comm.ExecuteReader();
            if (dr.HasRows)
            {
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource = dt;
            }
            comm.Dispose();
            conn.Close();
        }

        private void GraphQuery1(object sender, EventArgs e)
        {
            NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;Port=5432;Database=final;User Id=postgres;Password=P0stgre5ql;");
            conn.Open();
            NpgsqlCommand comm = new NpgsqlCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = "select distinct count(game.title), game.year_of_release, game.rating from game where game.year_of_release > 0 and game.rating like 'E' group by game.year_of_release, game.rating order by game.year_of_release asc";
            NpgsqlDataReader dr = comm.ExecuteReader();
            if (dr.HasRows)
            {
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource = dt;
            }
            comm.Dispose();
            conn.Close();

            // Put all the data from the datagridview into the chart
            FillChart("Games Rated E", 50);
        }

        private void GraphQuery2(object sender, EventArgs e)
        {
            NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;Port=5432;Database=final;User Id=postgres;Password=P0stgre5ql;");
            conn.Open();
            NpgsqlCommand comm = new NpgsqlCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = "select distinct count(game.title), game.year_of_release, game.genre from game where game.year_of_release > 0 and game.genre like 'Action' group by game.year_of_release, game.genre order by game.year_of_release asc";
            NpgsqlDataReader dr = comm.ExecuteReader();
            if (dr.HasRows)
            {
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource = dt;
            }
            comm.Dispose();
            conn.Close();

            // Put all the data from the datagridview into the chart
            FillChart("Action Games", 25);
        }

        private void GraphQuery3(object sender, EventArgs e)
        {
            NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;Port=5432;Database=final;User Id=postgres;Password=P0stgre5ql;");
            conn.Open();
            NpgsqlCommand comm = new NpgsqlCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = "select distinct count(game.title), game.year_of_release, publishes.publisher_title from game, publishes where game.title = publishes.game_title and publishes.publisher_title like 'Nintendo' and game.year_of_release > 0 group by game.year_of_release, publishes.publisher_title order by game.year_of_release asc";
            NpgsqlDataReader dr = comm.ExecuteReader();
            if (dr.HasRows)
            {
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource = dt;
            }
            comm.Dispose();
            conn.Close();

            // Put all the data from the datagridview into the chart
            FillChart("Nintendo Games", 5);
        }

        private void GraphQuery4(object sender, EventArgs e)
        {
            NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;Port=5432;Database=final;User Id=postgres;Password=P0stgre5ql;");
            conn.Open();
            NpgsqlCommand comm = new NpgsqlCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = "select distinct count(game.title), game.year_of_release from game, score, scores where scores.game_title = game.title and scores.score_id = score.score_id and score.critic_score >= 75 and game.year_of_release > 0 group by game.year_of_release order by game.year_of_release asc";
            NpgsqlDataReader dr = comm.ExecuteReader();
            if (dr.HasRows)
            {
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource = dt;
            }
            comm.Dispose();
            conn.Close();

            // Put all the data from the datagridview into the chart
            FillChart("Games Scoring At Least 75", 50);
        }

        private void GraphQuery5(object sender, EventArgs e)
        {
            NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;Port=5432;Database=final;User Id=postgres;Password=P0stgre5ql;");
            conn.Open();
            NpgsqlCommand comm = new NpgsqlCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = "select distinct count(game.title), game.year_of_release from game, sales, earns where earns.game_title = game.title and earns.sales_id = sales.sales_id and sales.global_sales >= 500 and game.year_of_release > 0 group by game.year_of_release order by game.year_of_release asc";
            NpgsqlDataReader dr = comm.ExecuteReader();
            if (dr.HasRows)
            {
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource = dt;
            }
            comm.Dispose();
            conn.Close();

            // Put all the data from the datagridview into the chart
            FillChart("Games Sold", 5);
        }

        private void PutDataInChart()
        {
            chartList1.Clear();
            chartList2.Clear();

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                int va = Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value);
                int va2 = Convert.ToInt32(dataGridView1.Rows[i].Cells[1].Value);
                chartList1.Add(va);
                chartList2.Add(va2);
            }
        }

        private void FillChart(string seriesName, int yInterval)
        {
            // Put all the data from the datagridview into the chart
            foreach (var series in chart1.Series)
            {
                series.Points.Clear();
            }
            chart1.Series.Clear();
            PutDataInChart();

            var objChart1 = chart1.ChartAreas[0];
            objChart1.AxisX.MajorGrid.Interval = 1;
            objChart1.AxisY.MajorGrid.Interval = yInterval;

            series1.ChartType = SeriesChartType.Line;
            series1.Name = seriesName;
            chart1.Series.Add(series1);
            chart1.Series[0].ChartArea = "ChartArea1";

            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                chart1.Series[seriesName].Points.AddXY(chartList2[i], chartList1[i]);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }
    }
}
