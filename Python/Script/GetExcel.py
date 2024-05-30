import os
import pandas as pd

# รับเส้นทางเต็มของไฟล์ Excel
current_directory = os.path.dirname(os.path.abspath(__file__))
excel_file_path = os.path.join(current_directory, '89349-T11013210-576-1F1.xlsx')

# อ่านไฟล์ Excel
data_frame = pd.read_excel(excel_file_path)

# แสดงข้อมูล
print(data_frame)
