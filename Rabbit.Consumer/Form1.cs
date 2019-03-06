using RabbitMQ.Client.Events;
using System;
using System.Windows.Forms;

namespace Rabbit.Consumer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private static Consumer _consumer;

        private void Form1_Load(object sender, EventArgs e)
        {
            _consumer = new Consumer("Customer");
            _consumer.ConsumerEvent.Received += ConsumerEvent_Received;
            ConsumerEvent_Received(sender, new BasicDeliverEventArgs());
        }

        private void ConsumerEvent_Received(object sender, BasicDeliverEventArgs e)
        {

        }
    }
}
