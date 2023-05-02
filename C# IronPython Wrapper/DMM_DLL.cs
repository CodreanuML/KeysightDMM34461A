using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMM_DLL
{
    public class DMM
    {


        /// ONE READ VOLTAGE


        public static double one_read_voltage()
        {
            var eng = IronPython.Hosting.Python.CreateEngine();
            var scope = eng.CreateScope();
            eng.Execute(@"

import sys
sys.path.append(r'C:\Program Files\IronPython 3.4\Lib')
import socket
import time
s=socket.socket(socket.AF_INET, socket.SOCK_STREAM)
s.connect(('192.168.1.1', 5025))
s.setsockopt(socket.IPPROTO_TCP, socket.TCP_NODELAY, 1)
s.settimeout(2)



def one_read_v():
	try:
		s.send('Measure:VOLTage:DC?\n'.encode())	
	except:
		return 0
	value=float(s.recv(1000))

	s.close()

	return value

value=one_read_v()
", scope);

            double one_read = scope.GetVariable("value");

            return one_read;

        }


        /// ONE READ CURRENT

        public static double one_read_current()
        {
            var eng = IronPython.Hosting.Python.CreateEngine();
            var scope = eng.CreateScope();
            eng.Execute(@"

import sys
sys.path.append(r'C:\Program Files\IronPython 3.4\Lib')
import socket
import time
s=socket.socket(socket.AF_INET, socket.SOCK_STREAM)
s.connect(('192.168.1.1', 5025))
s.setsockopt(socket.IPPROTO_TCP, socket.TCP_NODELAY, 1)
s.settimeout(2)



def one_read_c():
	try:
		s.send('Measure:CURRent:DC?\n'.encode())	
	except:
		return 0
	value=float(s.recv(1000))

	s.close()

	return value

value=one_read_c()
", scope);

            double one_read = scope.GetVariable("value");

            return one_read;

        }


        /// MULTIPLE VOLTAGE READS

        public static double multiple_read_voltage(int NrOfTRR)
        {
            var eng = IronPython.Hosting.Python.CreateEngine();
            var scope = eng.CreateScope();
            scope.SetVariable("NrOfTriess", NrOfTRR);
            eng.Execute(@"

import sys
sys.path.append(r'C:\Program Files\IronPython 3.4\Lib')
import socket
import time
s=socket.socket(socket.AF_INET, socket.SOCK_STREAM)
s.connect(('192.168.1.1', 5025))
s.setsockopt(socket.IPPROTO_TCP, socket.TCP_NODELAY, 1)
s.settimeout(2)



def multiple_read_voltag(NrOfTries):
	med=0
	for i in range(0,NrOfTries):
		try:
			s.send('Measure:VOLTage:DC?\n'.encode())
			
			med=med+float(s.recv(1000))
		except:
			return 0

	return med/NrOfTries 	
	
	s.close()
value=multiple_read_voltag(NrOfTriess)
", scope);

            double one_read = scope.GetVariable("value");

            return one_read;

        }


        /// MULTIPLE CURRENT READS

        public static double multiple_read_current(int NrOfTRR)
        {
            var eng = IronPython.Hosting.Python.CreateEngine();
            var scope = eng.CreateScope();
            scope.SetVariable("NrOfTriess", NrOfTRR);
            eng.Execute(@"

import sys
sys.path.append(r'C:\Program Files\IronPython 3.4\Lib')
import socket
import time
s=socket.socket(socket.AF_INET, socket.SOCK_STREAM)
s.connect(('192.168.1.1', 5025))
s.setsockopt(socket.IPPROTO_TCP, socket.TCP_NODELAY, 1)
s.settimeout(2)



def multiple_read_c(NrOfTries):
	med=0
	for i in range(0,NrOfTries):
		try:
			s.send('Measure:CURRent:DC?\n'.encode())
			
			med=med+float(s.recv(1000))
		except:
			return 0

	return med/NrOfTries 	
	
	s.close()
value=multiple_read_c(NrOfTriess)
", scope);

            double one_read = scope.GetVariable("value");

            return one_read;

        }

        ///TIME VOLTAGE READS

        public static double time_read_voltage(int TimeS)
        {
            var eng = IronPython.Hosting.Python.CreateEngine();
            var scope = eng.CreateScope();
            scope.SetVariable("timesec", TimeS);
            eng.Execute(@"

import sys
sys.path.append(r'C:\Program Files\IronPython 3.4\Lib')
import socket
import time
s=socket.socket(socket.AF_INET, socket.SOCK_STREAM)
s.connect(('192.168.1.1', 5025))
s.setsockopt(socket.IPPROTO_TCP, socket.TCP_NODELAY, 1)
s.settimeout(2)



def time_read_v(timesec):
	date1=time.time()
	date2=time.time()
	med=0
	counter=0
	while ((date2-date1)<timesec):
		try:
			s.send('Measure:VOLTage:DC?\n'.encode())		
			counter=counter+1
			med=med+float(s.recv(1000))
		except:
			return 0

		date2=time.time()
	
	return med/counter

	s.close()


value=time_read_v(timesec)
", scope);

            double one_read = scope.GetVariable("value");

            return one_read;

        }


        ///TIME CURRENT READS

        public static double time_read_current(int TimeS)
        {
            var eng = IronPython.Hosting.Python.CreateEngine();
            var scope = eng.CreateScope();
            scope.SetVariable("timesec", TimeS);
            eng.Execute(@"

import sys
sys.path.append(r'C:\Program Files\IronPython 3.4\Lib')
import socket
import time
s=socket.socket(socket.AF_INET, socket.SOCK_STREAM)
s.connect(('192.168.1.1', 5025))
s.setsockopt(socket.IPPROTO_TCP, socket.TCP_NODELAY, 1)
s.settimeout(2)



def time_read_i(timesec):
	date1=time.time()
	date2=time.time()
	med=0
	counter=0
	while ((date2-date1)<timesec):
		try:
			s.send('Measure:CURRent:DC?\n'.encode())		
			counter=counter+1
			med=med+float(s.recv(1000))
		except:
			return 0

		date2=time.time()
	
	return med/counter

	s.close()


value=time_read_i(timesec)
", scope);

            double one_read = scope.GetVariable("value");

            return one_read;

        }


    };

}
