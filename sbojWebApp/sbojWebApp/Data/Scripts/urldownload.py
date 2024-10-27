import requests
import os

def download_images(url_list, save_folder="C:/Users/GRIGS\source/repos/NValchanov09/sboj.bg/sbojWebApp/sbojWebApp/Data/Scripts/logos"):
    if not os.path.exists(save_folder):
        os.makedirs(save_folder)

    cnt = 0

    for url in url_list:
        try:
            response = requests.get(url)
            response.raise_for_status()

            slash_position = url.rfind('/')

            if slash_position != -1:
                file_name = url[slash_position + 1:]
            else:
                file_name = ""

            file_location = f"{save_folder}/image_{cnt + 1}.{file_name}"
            
            with open(file_location, "wb") as f:
                f.write(response.content)
            
            print(f"Downloaded: {file_location}")
            cnt = cnt + 1
        
        except requests.exceptions.RequestException as e:
            print(f"Failed to download image from {url}. Error: {e}")

url_list = [
    "https://logos-world.net/wp-content/uploads/2022/02/SAP-Logo.png",
    "https://logos-world.net/wp-content/uploads/2020/09/IBM-Logo.png",
    "https://www.nemetschek.bg/images/nemetschek-white.svg",
    "https://logos-world.net/wp-content/uploads/2020/08/Bosch-Logo.png",
    "https://logos-world.net/wp-content/uploads/2021/03/Telus-Logo.png",
    "https://stroiko2000.com/wp-content/uploads/2020/10/MYPOS-logo-PNG.png",
    
]

download_images(url_list)
