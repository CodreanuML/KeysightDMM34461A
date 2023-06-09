import socket
import time

#CREATING TCP - IP COMMUNICATION USING SOCKET MODULE 

s=socket.socket(socket.AF_INET, socket.SOCK_STREAM)
s.connect(('192.168.1.1', 5025))
s.setsockopt(socket.IPPROTO_TCP, socket.TCP_NODELAY, 1)
s.settimeout(2)


# ONE VOLTAGE READS - SEE MANUAL FOR COMMANDS ON TCP 
def one_read_voltage():
	try:
		s.send('Measure:VOLTage:DC?\n'.encode())
		print ('VOLTAGE : ' + str(float(s.recv(1000))) + ' Volts')
	except:
		print('Connection Failed')

	s.close()

	
# ONE CURRENT READS - SEE MANUAL FOR COMMANDS ON TCP 
def one_read_current():
	try:
		s.send('Measure:CURRent:DC?\n'.encode())
		print ('CURRent: ' + str(float(s.recv(1000)))+' Amps')
	except:
		print('Connection Failed')
	s.close()

# MULTIPLE VOLTAGES READS - SEE MANUAL FOR COMMANDS ON TCP 		
def multiple_read_voltage(NrOfTries):
	med=0
	for i in range(0,NrOfTries):
		try:
			s.send('Measure:VOLTage:DC?\n'.encode())
			
			med=med+float(s.recv(1000))
		except:
			print('Connection Failed')

	print ('VOLTAGE -MED VALUE : ' + str(med/NrOfTries) + ' Volts')	
	
	s.close()

# MULTIPLE CURRENTS READS - SEE MANUAL FOR COMMANDS ON TCP 	
def multiple_read_current(NrOfTries):
	med=0
	for i in range(0,NrOfTries):
		try:
			s.send('Measure:CURRent:DC?\n'.encode())
			
			med=med+float(s.recv(1000))
		except:
			print('Connection Failed')

	print ('CURRent -MED VALUE : ' + str(med/NrOfTries) + ' Amps')	
	s.close()
	
	
#VOLTAGE READ (IN A SPECIFIED INTERVAL OF TIME - IN SECONDS)
	
def time_read_voltage(timesec):
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
			print('Connection Failed')

		date2=time.time()
	print(date2-date1)
	print ('VOLTAGE -MED VALUE : ' + str(med/counter) + ' Volts')

	s.close()

#CURRENT READ (IN A SPECIFIED INTERVAL OF TIME - IN SECONDS)	
def time_read_current(timesec):
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
			print('Connection Failed')

		date2=time.time()

	print(date2-date1)
	print ('CURRent -MED VALUE : ' + str(med/counter) + ' Volts')





