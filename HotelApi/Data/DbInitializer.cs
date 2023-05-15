using HotelApi.Models;

namespace HotelApi.Data
{
    public static class DbInitializer
    {
        public static void Initialize(HotelContext context)
        {
            if (context.Rooms.Any())
                return;

            var roomTypes = new RoomType[]
            {
                new RoomType
                {
                    Name = "Single",
                    BasePrice = 3700,
                    Description = "A small cozy studio room, made in a calm color scheme," +
                    " has a rest after long excursions, walks and work." +
                    " The room has all the necessary furniture for work and leisure.",
                    ImageUrl = "https://ik.imagekit.io/x7vs6adbh/hotel_room.jpeg?ik-sdk-version=javascript-1.4.3&updatedAt=1677073528289"
                },

                new RoomType
                {
                    Name = "Double",
                    BasePrice = 3700,
                    Description = "A small cozy studio room (15 sq.m.)," +
                    " which can accommodate one or two people, made in a calm color scheme," +
                    " has a rest after long excursions, walks and work. " +
                    "The room has all the necessary furniture for work and leisure.",
                    ImageUrl = "https://ik.imagekit.io/x7vs6adbh/hotel_room.jpeg?ik-sdk-version=javascript-1.4.3&updatedAt=1677073528289"
                },

                new RoomType
                {
                    Name = "Junior Suite",
                    BasePrice = 5300,
                    Description = "Spacious, beautiful, exquisitely decorated room that contains" +
                    " everything you need for a comfortable stay and rest. Each room has an individual design.",
                    ImageUrl = "https://ik.imagekit.io/x7vs6adbh/hotel_room.jpeg?ik-sdk-version=javascript-1.4.3&updatedAt=1677073528289"
                },

                new RoomType
                {
                    Name = "Luxury Classic",
                    BasePrice = 5900,
                    Description = "A spacious, beautiful two-room suite," +
                    " where you will find a cozy bedroom and an exquisitely decorated living room." +
                    " The room contains everything you need for a comfortable stay and rest." +
                    " Each room has an individual design.",
                    ImageUrl = "https://ik.imagekit.io/x7vs6adbh/hotel_room.jpeg?ik-sdk-version=javascript-1.4.3&updatedAt=1677073528289"
                }
            };

            context.RoomTypes.AddRange(roomTypes);
            context.SaveChanges();

            var rooms = new Room[]
            {
                 new Room
                    {
                        RoomType = roomTypes.FirstOrDefault(r => r.Name == "Single")!,
                        RoomTypeId = roomTypes.FirstOrDefault(r => r.Name == "Single")!.Id,
                        Available = true,
                        Description = "A small cozy studio room, made in a calm color scheme," +
                        " has a rest after long excursions, walks and work." +
                        " The room has all the necessary furniture for work and leisure." +
                        "First.",
                        Number = 1
                    },

                    new Room
                    {
                        RoomType = roomTypes.FirstOrDefault(r => r.Name == "Single")!,
                        RoomTypeId = roomTypes.FirstOrDefault(r => r.Name == "Single")!.Id,
                        Available = true,
                        Description = "A small cozy studio room, made in a calm color scheme," +
                        " has a rest after long excursions, walks and work." +
                        " The room has all the necessary furniture for work and leisure." +
                        " First.",
                        Number = 2
                    },


                    new Room
                    {
                        RoomType = roomTypes.FirstOrDefault(r => r.Name == "Double")!,
                        RoomTypeId = roomTypes.FirstOrDefault(r => r.Name == "Double")!.Id,
                        Available = true,
                        Description = "A small cozy studio room (15 sq.m.)," +
                        " which can accommodate one or two people, made in a calm color scheme," +
                        " has a rest after long excursions, walks and work. " +
                        "The room has all the necessary furniture for work and leisure. " +
                        "Double.",
                        Number = 1
                    },

                    new Room
                    {
                        RoomType = roomTypes.FirstOrDefault(r => r.Name == "Double")!,
                        RoomTypeId = roomTypes.FirstOrDefault(r => r.Name == "Double")!.Id,
                        Available = true,
                        Description = "A small cozy studio room (15 sq.m.)," +
                        " which can accommodate one or two people, made in a calm color scheme," +
                        " has a rest after long excursions, walks and work. " +
                        "The room has all the necessary furniture for work and leisure. " +
                        "Double.",
                        Number = 2
                    },


                    new Room
                    {
                        RoomType = roomTypes.FirstOrDefault(r => r.Name == "Junior Suite")!,
                        RoomTypeId = roomTypes.FirstOrDefault(r => r.Name == "Junior Suite")!.Id,
                        Available = true,
                        Description = "Spacious, beautiful, exquisitely decorated room that contains" +
                        " everything you need for a comfortable stay and rest." +
                        " Each room has an individual design. " +
                        "Junior Suite.",
                        Number = 1
                    },

                    new Room
                    {
                        RoomType = roomTypes.FirstOrDefault(r => r.Name == "Junior Suite")!,
                        RoomTypeId = roomTypes.FirstOrDefault(r => r.Name == "Junior Suite")!.Id,
                        Available = true,
                        Description = "Spacious, beautiful, exquisitely decorated room that contains" +
                        " everything you need for a comfortable stay and rest." +
                        " Each room has an individual design. " +
                        "Junior Suite.",
                        Number = 2
                    },


                    new Room
                    {
                        RoomType = roomTypes.FirstOrDefault(r => r.Name == "Luxury Classic")!,
                        RoomTypeId = roomTypes.FirstOrDefault(r => r.Name == "Luxury Classic")!.Id,
                        Available = true,
                        Description = "A spacious, beautiful two-room suite," +
                        " where you will find a cozy bedroom and an exquisitely decorated living room." +
                        " The room contains everything you need for a comfortable stay and rest." +
                        " Each room has an individual design. " +
                        "Luxury Classic.",
                        Number = 1
                    },

                    new Room
                    {
                        RoomType = roomTypes.FirstOrDefault(r => r.Name == "Luxury Classic")!,
                        RoomTypeId = roomTypes.FirstOrDefault(r => r.Name == "Luxury Classic")!.Id,
                        Available = true,
                        Description = "A spacious, beautiful two-room suite," +
                        " where you will find a cozy bedroom and an exquisitely decorated living room." +
                        " The room contains everything you need for a comfortable stay and rest." +
                        " Each room has an individual design. " +
                        "Luxury Classic.",
                        Number = 2
                    },
            };

            context.Rooms.AddRange(rooms);
            context.SaveChanges();


            var roomImages = new RoomImage[]
            {
                new RoomImage
                {
                    ImageUrl = "https://ik.imagekit.io/x7vs6adbh/hotel_room16.JPG?updatedAt=1682158421465",
                    RoomId = rooms.First(r => r.Number == 1 && r.RoomType.Name == "Single").Id,
                    Room = rooms.First(r => r.Number == 1 && r.RoomType.Name == "Single"),
                },

                new RoomImage
                {
                    ImageUrl = "https://ik.imagekit.io/x7vs6adbh/hotel_room16.JPG?updatedAt=1682158421465",
                    RoomId = rooms.First(r => r.Number == 2 && r.RoomType.Name == "Single").Id,
                    Room = rooms.First(r => r.Number == 2 && r.RoomType.Name == "Single"),
                },

                new RoomImage
                {
                    ImageUrl = "https://ik.imagekit.io/x7vs6adbh/hotel_room16.JPG?updatedAt=1682158421465",
                    RoomId = rooms.First(r => r.Number == 3 && r.RoomType.Name == "Single").Id,
                    Room = rooms.First(r => r.Number == 3 && r.RoomType.Name == "Single"),
                },


                new RoomImage
                {
                    ImageUrl = "https://ik.imagekit.io/x7vs6adbh/hotel_room16.JPG?updatedAt=1682158421465",
                    RoomId = rooms.First(r => r.Number == 1 && r.RoomType.Name == "Double").Id,
                    Room = rooms.First(r => r.Number == 1 && r.RoomType.Name == "Double"),
                },

                new RoomImage
                {
                    ImageUrl = "https://ik.imagekit.io/x7vs6adbh/hotel_room16.JPG?updatedAt=1682158421465",
                    RoomId = rooms.First(r => r.Number == 2 && r.RoomType.Name == "Double").Id,
                    Room = rooms.First(r => r.Number == 2 && r.RoomType.Name == "Double"),
                },


                new RoomImage
                {
                    ImageUrl = "https://ik.imagekit.io/x7vs6adbh/hotel_room16.JPG?updatedAt=1682158421465",
                    RoomId = rooms.First(r => r.Number == 1 && r.RoomType.Name == "Junior Suite").Id,
                    Room = rooms.First(r => r.Number == 1 && r.RoomType.Name == "Junior Suite"),
                },

                new RoomImage
                {
                    ImageUrl = "https://ik.imagekit.io/x7vs6adbh/hotel_room16.JPG?updatedAt=1682158421465",
                    RoomId = rooms.First(r => r.Number == 2 && r.RoomType.Name == "Junior Suite").Id,
                    Room = rooms.First(r => r.Number == 2 && r.RoomType.Name == "Junior Suite"),
                },


                new RoomImage
                {
                    ImageUrl = "https://ik.imagekit.io/x7vs6adbh/hotel_room16.JPG?updatedAt=1682158421465",
                    RoomId = rooms.First(r => r.Number == 1 && r.RoomType.Name == "Luxury Classic").Id,
                    Room = rooms.First(r => r.Number == 1 && r.RoomType.Name == "Luxury Classic"),
                },

                new RoomImage
                {
                    ImageUrl = "https://ik.imagekit.io/x7vs6adbh/hotel_room16.JPG?updatedAt=1682158421465",
                    RoomId = rooms.First(r => r.Number == 2 && r.RoomType.Name == "Luxury Classic").Id,
                    Room = rooms.First(r => r.Number == 2 && r.RoomType.Name == "Luxury Classic"),
                },




                 new RoomImage
                {
                    ImageUrl = "https://ik.imagekit.io/x7vs6adbh/hotel_room8.jpg?updatedAt=1682158422303",
                    RoomId = rooms.First(r => r.Number == 1 && r.RoomType.Name == "Single").Id,
                    Room = rooms.First(r => r.Number == 1 && r.RoomType.Name == "Single"),
                },

                new RoomImage
                {
                    ImageUrl = "https://ik.imagekit.io/x7vs6adbh/hotel_room8.jpg?updatedAt=1682158422303",
                    RoomId = rooms.First(r => r.Number == 2 && r.RoomType.Name == "Single").Id,
                    Room = rooms.First(r => r.Number == 2 && r.RoomType.Name == "Single"),
                },

                new RoomImage
                {
                    ImageUrl = "https://ik.imagekit.io/x7vs6adbh/hotel_room8.jpg?updatedAt=1682158422303",
                    RoomId = rooms.First(r => r.Number == 3 && r.RoomType.Name == "Single").Id,
                    Room = rooms.First(r => r.Number == 3 && r.RoomType.Name == "Single"),
                },


                new RoomImage
                {
                    ImageUrl = "https://ik.imagekit.io/x7vs6adbh/hotel_room8.jpg?updatedAt=1682158422303",
                    RoomId = rooms.First(r => r.Number == 1 && r.RoomType.Name == "Double").Id,
                    Room = rooms.First(r => r.Number == 1 && r.RoomType.Name == "Double"),
                },

                new RoomImage
                {
                    ImageUrl = "https://ik.imagekit.io/x7vs6adbh/hotel_room8.jpg?updatedAt=1682158422303",
                    RoomId = rooms.First(r => r.Number == 2 && r.RoomType.Name == "Double").Id,
                    Room = rooms.First(r => r.Number == 2 && r.RoomType.Name == "Double"),
                },


                new RoomImage
                {
                    ImageUrl = "https://ik.imagekit.io/x7vs6adbh/hotel_room8.jpg?updatedAt=1682158422303",
                    RoomId = rooms.First(r => r.Number == 1 && r.RoomType.Name == "Junior Suite").Id,
                    Room = rooms.First(r => r.Number == 1 && r.RoomType.Name == "Junior Suite"),
                },

                new RoomImage
                {
                    ImageUrl = "https://ik.imagekit.io/x7vs6adbh/hotel_room8.jpg?updatedAt=1682158422303",
                    RoomId = rooms.First(r => r.Number == 2 && r.RoomType.Name == "Junior Suite").Id,
                    Room = rooms.First(r => r.Number == 2 && r.RoomType.Name == "Junior Suite"),
                },


                new RoomImage
                {
                    ImageUrl = "https://ik.imagekit.io/x7vs6adbh/hotel_room8.jpg?updatedAt=1682158422303",
                    RoomId = rooms.First(r => r.Number == 1 && r.RoomType.Name == "Luxury Classic").Id,
                    Room = rooms.First(r => r.Number == 1 && r.RoomType.Name == "Luxury Classic"),
                },

                new RoomImage
                {
                    ImageUrl = "https://ik.imagekit.io/x7vs6adbh/hotel_room8.jpg?updatedAt=1682158422303",
                    RoomId = rooms.First(r => r.Number == 2 && r.RoomType.Name == "Luxury Classic").Id,
                    Room = rooms.First(r => r.Number == 2 && r.RoomType.Name == "Luxury Classic"),
                },




                new RoomImage
                {
                    ImageUrl = "https://ik.imagekit.io/x7vs6adbh/hotel_room13.jpg?updatedAt=1682158421039",
                    RoomId = rooms.First(r => r.Number == 1 && r.RoomType.Name == "Single").Id,
                    Room = rooms.First(r => r.Number == 1 && r.RoomType.Name == "Single"),
                },

                new RoomImage
                {
                    ImageUrl = "https://ik.imagekit.io/x7vs6adbh/hotel_room13.jpg?updatedAt=1682158421039",
                    RoomId = rooms.First(r => r.Number == 2 && r.RoomType.Name == "Single").Id,
                    Room = rooms.First(r => r.Number == 2 && r.RoomType.Name == "Single"),
                },

                new RoomImage
                {
                    ImageUrl = "https://ik.imagekit.io/x7vs6adbh/hotel_room13.jpg?updatedAt=1682158421039",
                    RoomId = rooms.First(r => r.Number == 3 && r.RoomType.Name == "Single").Id,
                    Room = rooms.First(r => r.Number == 3 && r.RoomType.Name == "Single"),
                },


                new RoomImage
                {
                    ImageUrl = "https://ik.imagekit.io/x7vs6adbh/hotel_room13.jpg?updatedAt=1682158421039",
                    RoomId = rooms.First(r => r.Number == 1 && r.RoomType.Name == "Double").Id,
                    Room = rooms.First(r => r.Number == 1 && r.RoomType.Name == "Double"),
                },

                new RoomImage
                {
                    ImageUrl = "https://ik.imagekit.io/x7vs6adbh/hotel_room13.jpg?updatedAt=1682158421039",
                    RoomId = rooms.First(r => r.Number == 2 && r.RoomType.Name == "Double").Id,
                    Room = rooms.First(r => r.Number == 2 && r.RoomType.Name == "Double"),
                },


                new RoomImage
                {
                    ImageUrl = "https://ik.imagekit.io/x7vs6adbh/hotel_room13.jpg?updatedAt=1682158421039",
                    RoomId = rooms.First(r => r.Number == 1 && r.RoomType.Name == "Junior Suite").Id,
                    Room = rooms.First(r => r.Number == 1 && r.RoomType.Name == "Junior Suite"),
                },

                new RoomImage
                {
                    ImageUrl = "https://ik.imagekit.io/x7vs6adbh/hotel_room13.jpg?updatedAt=1682158421039",
                    RoomId = rooms.First(r => r.Number == 2 && r.RoomType.Name == "Junior Suite").Id,
                    Room = rooms.First(r => r.Number == 2 && r.RoomType.Name == "Junior Suite"),
                },


                new RoomImage
                {
                    ImageUrl = "https://ik.imagekit.io/x7vs6adbh/hotel_room13.jpg?updatedAt=1682158421039",
                    RoomId = rooms.First(r => r.Number == 1 && r.RoomType.Name == "Luxury Classic").Id,
                    Room = rooms.First(r => r.Number == 1 && r.RoomType.Name == "Luxury Classic"),
                },

                new RoomImage
                {
                    ImageUrl = "https://ik.imagekit.io/x7vs6adbh/hotel_room13.jpg?updatedAt=1682158421039",
                    RoomId = rooms.First(r => r.Number == 2 && r.RoomType.Name == "Luxury Classic").Id,
                    Room = rooms.First(r => r.Number == 2 && r.RoomType.Name == "Luxury Classic"),
                },




                new RoomImage
                {
                    ImageUrl = "https://ik.imagekit.io/x7vs6adbh/hotel_room15.jpg?updatedAt=1682158421891",
                    RoomId = rooms.First(r => r.Number == 1 && r.RoomType.Name == "Single").Id,
                    Room = rooms.First(r => r.Number == 1 && r.RoomType.Name == "Single"),
                },

                new RoomImage
                {
                    ImageUrl = "https://ik.imagekit.io/x7vs6adbh/hotel_room15.jpg?updatedAt=1682158421891",
                    RoomId = rooms.First(r => r.Number == 2 && r.RoomType.Name == "Single").Id,
                    Room = rooms.First(r => r.Number == 2 && r.RoomType.Name == "Single"),
                },

                new RoomImage
                {
                    ImageUrl = "https://ik.imagekit.io/x7vs6adbh/hotel_room15.jpg?updatedAt=1682158421891",
                    RoomId = rooms.First(r => r.Number == 3 && r.RoomType.Name == "Single").Id,
                    Room = rooms.First(r => r.Number == 3 && r.RoomType.Name == "Single"),
                },


                new RoomImage
                {
                    ImageUrl = "https://ik.imagekit.io/x7vs6adbh/hotel_room15.jpg?updatedAt=1682158421891",
                    RoomId = rooms.First(r => r.Number == 1 && r.RoomType.Name == "Double").Id,
                    Room = rooms.First(r => r.Number == 1 && r.RoomType.Name == "Double"),
                },

                new RoomImage
                {
                    ImageUrl = "https://ik.imagekit.io/x7vs6adbh/hotel_room15.jpg?updatedAt=1682158421891",
                    RoomId = rooms.First(r => r.Number == 2 && r.RoomType.Name == "Double").Id,
                    Room = rooms.First(r => r.Number == 2 && r.RoomType.Name == "Double"),
                },


                new RoomImage
                {
                    ImageUrl = "https://ik.imagekit.io/x7vs6adbh/hotel_room15.jpg?updatedAt=1682158421891",
                    RoomId = rooms.First(r => r.Number == 1 && r.RoomType.Name == "Junior Suite").Id,
                    Room = rooms.First(r => r.Number == 1 && r.RoomType.Name == "Junior Suite"),
                },

                new RoomImage
                {
                    ImageUrl = "https://ik.imagekit.io/x7vs6adbh/hotel_room15.jpg?updatedAt=1682158421891",
                    RoomId = rooms.First(r => r.Number == 2 && r.RoomType.Name == "Junior Suite").Id,
                    Room = rooms.First(r => r.Number == 2 && r.RoomType.Name == "Junior Suite"),
                },


                new RoomImage
                {
                    ImageUrl = "https://ik.imagekit.io/x7vs6adbh/hotel_room15.jpg?updatedAt=1682158421891",
                    RoomId = rooms.First(r => r.Number == 1 && r.RoomType.Name == "Luxury Classic").Id,
                    Room = rooms.First(r => r.Number == 1 && r.RoomType.Name == "Luxury Classic"),
                },

                new RoomImage
                {
                    ImageUrl = "https://ik.imagekit.io/x7vs6adbh/hotel_room15.jpg?updatedAt=1682158421891",
                    RoomId = rooms.First(r => r.Number == 2 && r.RoomType.Name == "Luxury Classic").Id,
                    Room = rooms.First(r => r.Number == 2 && r.RoomType.Name == "Luxury Classic"),
                },




                new RoomImage
                {
                    ImageUrl = "https://ik.imagekit.io/x7vs6adbh/hotel_room9.jpg?updatedAt=1682158420523",
                    RoomId = rooms.First(r => r.Number == 1 && r.RoomType.Name == "Single").Id,
                    Room = rooms.First(r => r.Number == 1 && r.RoomType.Name == "Single"),
                },

                new RoomImage
                {
                    ImageUrl = "https://ik.imagekit.io/x7vs6adbh/hotel_room9.jpg?updatedAt=1682158420523",
                    RoomId = rooms.First(r => r.Number == 2 && r.RoomType.Name == "Single").Id,
                    Room = rooms.First(r => r.Number == 2 && r.RoomType.Name == "Single"),
                },

                new RoomImage
                {
                    ImageUrl = "https://ik.imagekit.io/x7vs6adbh/hotel_room9.jpg?updatedAt=1682158420523",
                    RoomId = rooms.First(r => r.Number == 3 && r.RoomType.Name == "Single").Id,
                    Room = rooms.First(r => r.Number == 3 && r.RoomType.Name == "Single"),
                },


                new RoomImage
                {
                    ImageUrl = "https://ik.imagekit.io/x7vs6adbh/hotel_room9.jpg?updatedAt=1682158420523",
                    RoomId = rooms.First(r => r.Number == 1 && r.RoomType.Name == "Double").Id,
                    Room = rooms.First(r => r.Number == 1 && r.RoomType.Name == "Double"),
                },

                new RoomImage
                {
                    ImageUrl = "https://ik.imagekit.io/x7vs6adbh/hotel_room9.jpg?updatedAt=1682158420523",
                    RoomId = rooms.First(r => r.Number == 2 && r.RoomType.Name == "Double").Id,
                    Room = rooms.First(r => r.Number == 2 && r.RoomType.Name == "Double"),
                },


                new RoomImage
                {
                    ImageUrl = "https://ik.imagekit.io/x7vs6adbh/hotel_room9.jpg?updatedAt=1682158420523",
                    RoomId = rooms.First(r => r.Number == 1 && r.RoomType.Name == "Junior Suite").Id,
                    Room = rooms.First(r => r.Number == 1 && r.RoomType.Name == "Junior Suite"),
                },

                new RoomImage
                {
                    ImageUrl = "https://ik.imagekit.io/x7vs6adbh/hotel_room9.jpg?updatedAt=1682158420523",
                    RoomId = rooms.First(r => r.Number == 2 && r.RoomType.Name == "Junior Suite").Id,
                    Room = rooms.First(r => r.Number == 2 && r.RoomType.Name == "Junior Suite"),
                },


                new RoomImage
                {
                    ImageUrl = "https://ik.imagekit.io/x7vs6adbh/hotel_room9.jpg?updatedAt=1682158420523",
                    RoomId = rooms.First(r => r.Number == 1 && r.RoomType.Name == "Luxury Classic").Id,
                    Room = rooms.First(r => r.Number == 1 && r.RoomType.Name == "Luxury Classic"),
                },

                new RoomImage
                {
                    ImageUrl = "https://ik.imagekit.io/x7vs6adbh/hotel_room9.jpg?updatedAt=1682158420523",
                    RoomId = rooms.First(r => r.Number == 2 && r.RoomType.Name == "Luxury Classic").Id,
                    Room = rooms.First(r => r.Number == 2 && r.RoomType.Name == "Luxury Classic"),
                },




                new RoomImage
                {
                    ImageUrl = "https://ik.imagekit.io/x7vs6adbh/hotel_room14.jpeg?updatedAt=1682158420320",
                    RoomId = rooms.First(r => r.Number == 1 && r.RoomType.Name == "Single").Id,
                    Room = rooms.First(r => r.Number == 1 && r.RoomType.Name == "Single"),
                },

                new RoomImage
                {
                    ImageUrl = "https://ik.imagekit.io/x7vs6adbh/hotel_room14.jpeg?updatedAt=1682158420320",
                    RoomId = rooms.First(r => r.Number == 2 && r.RoomType.Name == "Single").Id,
                    Room = rooms.First(r => r.Number == 2 && r.RoomType.Name == "Single"),
                },

                new RoomImage
                {
                    ImageUrl = "https://ik.imagekit.io/x7vs6adbh/hotel_room14.jpeg?updatedAt=1682158420320",
                    RoomId = rooms.First(r => r.Number == 3 && r.RoomType.Name == "Single").Id,
                    Room = rooms.First(r => r.Number == 3 && r.RoomType.Name == "Single"),
                },


                new RoomImage
                {
                    ImageUrl = "https://ik.imagekit.io/x7vs6adbh/hotel_room14.jpeg?updatedAt=1682158420320",
                    RoomId = rooms.First(r => r.Number == 1 && r.RoomType.Name == "Double").Id,
                    Room = rooms.First(r => r.Number == 1 && r.RoomType.Name == "Double"),
                },

                new RoomImage
                {
                    ImageUrl = "https://ik.imagekit.io/x7vs6adbh/hotel_room14.jpeg?updatedAt=1682158420320",
                    RoomId = rooms.First(r => r.Number == 2 && r.RoomType.Name == "Double").Id,
                    Room = rooms.First(r => r.Number == 2 && r.RoomType.Name == "Double"),
                },


                new RoomImage
                {
                    ImageUrl = "https://ik.imagekit.io/x7vs6adbh/hotel_room14.jpeg?updatedAt=1682158420320",
                    RoomId = rooms.First(r => r.Number == 1 && r.RoomType.Name == "Junior Suite").Id,
                    Room = rooms.First(r => r.Number == 1 && r.RoomType.Name == "Junior Suite"),
                },

                new RoomImage
                {
                    ImageUrl = "https://ik.imagekit.io/x7vs6adbh/hotel_room14.jpeg?updatedAt=1682158420320",
                    RoomId = rooms.First(r => r.Number == 2 && r.RoomType.Name == "Junior Suite").Id,
                    Room = rooms.First(r => r.Number == 2 && r.RoomType.Name == "Junior Suite"),
                },


                new RoomImage
                {
                    ImageUrl = "https://ik.imagekit.io/x7vs6adbh/hotel_room14.jpeg?updatedAt=1682158420320",
                    RoomId = rooms.First(r => r.Number == 1 && r.RoomType.Name == "Luxury Classic").Id,
                    Room = rooms.First(r => r.Number == 1 && r.RoomType.Name == "Luxury Classic"),
                },

                new RoomImage
                {
                    ImageUrl = "https://ik.imagekit.io/x7vs6adbh/hotel_room14.jpeg?updatedAt=1682158420320",
                    RoomId = rooms.First(r => r.Number == 2 && r.RoomType.Name == "Luxury Classic").Id,
                    Room = rooms.First(r => r.Number == 2 && r.RoomType.Name == "Luxury Classic"),
                },




                new RoomImage
                {
                    ImageUrl = "https://ik.imagekit.io/x7vs6adbh/hotel_room12.jpg?updatedAt=1682158420223",
                    RoomId = rooms.First(r => r.Number == 1 && r.RoomType.Name == "Single").Id,
                    Room = rooms.First(r => r.Number == 1 && r.RoomType.Name == "Single"),
                },

                new RoomImage
                {
                    ImageUrl = "https://ik.imagekit.io/x7vs6adbh/hotel_room12.jpg?updatedAt=1682158420223",
                    RoomId = rooms.First(r => r.Number == 2 && r.RoomType.Name == "Single").Id,
                    Room = rooms.First(r => r.Number == 2 && r.RoomType.Name == "Single"),
                },

                new RoomImage
                {
                    ImageUrl = "https://ik.imagekit.io/x7vs6adbh/hotel_room12.jpg?updatedAt=1682158420223",
                    RoomId = rooms.First(r => r.Number == 3 && r.RoomType.Name == "Single").Id,
                    Room = rooms.First(r => r.Number == 3 && r.RoomType.Name == "Single"),
                },


                new RoomImage
                {
                    ImageUrl = "https://ik.imagekit.io/x7vs6adbh/hotel_room12.jpg?updatedAt=1682158420223",
                    RoomId = rooms.First(r => r.Number == 1 && r.RoomType.Name == "Double").Id,
                    Room = rooms.First(r => r.Number == 1 && r.RoomType.Name == "Double"),
                },

                new RoomImage
                {
                    ImageUrl = "https://ik.imagekit.io/x7vs6adbh/hotel_room12.jpg?updatedAt=1682158420223",
                    RoomId = rooms.First(r => r.Number == 2 && r.RoomType.Name == "Double").Id,
                    Room = rooms.First(r => r.Number == 2 && r.RoomType.Name == "Double"),
                },


                new RoomImage
                {
                    ImageUrl = "https://ik.imagekit.io/x7vs6adbh/hotel_room12.jpg?updatedAt=1682158420223",
                    RoomId = rooms.First(r => r.Number == 1 && r.RoomType.Name == "Junior Suite").Id,
                    Room = rooms.First(r => r.Number == 1 && r.RoomType.Name == "Junior Suite"),
                },

                new RoomImage
                {
                    ImageUrl = "https://ik.imagekit.io/x7vs6adbh/hotel_room12.jpg?updatedAt=1682158420223",
                    RoomId = rooms.First(r => r.Number == 2 && r.RoomType.Name == "Junior Suite").Id,
                    Room = rooms.First(r => r.Number == 2 && r.RoomType.Name == "Junior Suite"),
                },


                new RoomImage
                {
                    ImageUrl = "https://ik.imagekit.io/x7vs6adbh/hotel_room12.jpg?updatedAt=1682158420223",
                    RoomId = rooms.First(r => r.Number == 1 && r.RoomType.Name == "Luxury Classic").Id,
                    Room = rooms.First(r => r.Number == 1 && r.RoomType.Name == "Luxury Classic"),
                },

                new RoomImage
                {
                    ImageUrl = "https://ik.imagekit.io/x7vs6adbh/hotel_room12.jpg?updatedAt=1682158420223",
                    RoomId = rooms.First(r => r.Number == 2 && r.RoomType.Name == "Luxury Classic").Id,
                    Room = rooms.First(r => r.Number == 2 && r.RoomType.Name == "Luxury Classic"),
                },
            };

            context.RoomImages.AddRange(roomImages);
            context.SaveChanges();

            var guests = new Guest[]
            {
                new Guest { Name = "Степанов Иван Васильевич" },
                new Guest { Name = "Степанова Алина Геннадьевна" },
                new Guest { Name = "Петров Петр Петрович" },
                new Guest { Name = "Кузнецов Николай Евгеньевич" },
                new Guest { Name = "Карпова Вера Геннадьевна" },
                new Guest { Name = "Мустафин Никита Ринатович" },
                new Guest { Name = "Тарасов Иван Владимирович" },
                new Guest { Name = "Степанова Александра Александровна" },
                new Guest { Name = "Зименкова Марина Алексеевна" },
                new Guest { Name = "Бодрина Виктория Владимировна" }
            };

            context.Guests.AddRange(guests);
            context.SaveChanges();


            var bookings = new Booking[]
            {
                new Booking
                {
                    CheckIn = new DateTime(2023, 02, 25),
                    CheckOut = new DateTime(2023, 02, 28),
                    DaysOfStay = 3,
                    Paid = false,
                    TotalFee = 4000,
                    Guest = guests.FirstOrDefault(e => e.Name == "Петров Петр Петрович")!,
                    GuestId = guests.FirstOrDefault(e => e.Name == "Петров Петр Петрович")!.Id,
                    Room = rooms.FirstOrDefault(r => r.RoomType.Name == "Single" && r.Number == 1)!,
                    RoomId = rooms.FirstOrDefault(r => r.RoomType.Name == "Single" && r.Number == 1)!.Id,
                    Guests = 1
                },

                new Booking
                {
                    CheckIn = new DateTime(2023, 02, 25),
                    CheckOut = new DateTime(2023, 02, 27),
                    DaysOfStay = 2,
                    Paid = false,
                    TotalFee = 3000,
                    Guest = guests.FirstOrDefault(e => e.Name == "Степанов Иван Васильевич")!,
                    GuestId = guests.FirstOrDefault(e => e.Name == "Степанов Иван Васильевич")!.Id,
                    Room = rooms.FirstOrDefault(r => r.RoomType.Name == "Double" && r.Number == 2)!,
                    RoomId = rooms.FirstOrDefault(r => r.RoomType.Name == "Double" && r.Number == 2)!.Id,
                    Guests = 2
                },
            };

            context.Bookings.AddRange(bookings);
            context.SaveChanges();
        }
    }
}
