# Mail-Class
Mail gönderirken aynı şeyleri uzun uzun yazmak yerine sadece gerekli bilgileri verelim ve mail gönderelim.
Build alıp kendi projenize referans olarak ekleye bilirsiniz.


      Kullanımı
          //Bilgileri doldurma.
            MailSystem MS = new MailSystem
            {
                AMailAdress = "alıcı@domain.com",
                GMailAdress = "Gönderici@yandex.com",
                GMailPass = "gönderici şifresi",
                Icerik = "metin",
                Konu = "Konu"
            };
            
            //Eğer kendi hostunuz ve portunuz üzerinden gönderecek iseniz.            
            //MS.CustomHP("smtp.BenimHostum.com", 123);

            //Mail gönderme.
            MS.MailPost();
            
