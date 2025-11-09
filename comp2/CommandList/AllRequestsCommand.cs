using comp2.Controllers;
using Microsoft.AspNetCore.Http.HttpResults;
using MyMediator.Interfaces;
using MyMediator.Types;
using System;
using System.Security.Claims;
using static System.Net.WebRequestMethods;

namespace comp2.CommandList
{
//    Задание 07.11.25

//Дана база данных: it_company_1135(192.168.200.13, mariadb)

//К ней нужно разработать ряд контроллеров(все контроллеры делать не надо!! в списке отмечено, кто что делает).

//Общие требования для api:
//Настроить выдачу и проверку JWT-токенов(пример тут: https://github.com/stenly87/JwtSample_2025)
//Каждый делает контроллер для авторизации!

//Общие требования для контроллеров:
//! UserSid не передаётся в URL или теле запроса, если это касается действий от имени текущего пользователя.
//! Если операция требует указать другого пользователя (например, админ вручает бейдж), тогда userSid передаётся в теле запроса.
//! Все методы GET /.../my/... и GET /.../me работают с данными текущего пользователя (из JWT).
//! Все изменения (CreatedBy, ModifiedBy, DeletedBy) автоматически заполняются на основе UserSid из токена.
//! Обработка методов по CQRS (используем медиатор, https://github.com/stenly87/MyMediator), принимаем и возвращаем DTO-объекты, обработка команд в хэндлерах
//! Заметка: Методы PATCH предполагают работу не с полным DTO, а с DTO, в котором есть только изменяемый параметр (например: { "email": "newemail@example.com" })
//! Заметка: Некоторые методы требуют проверки прав - в бд есть роли, проверяйте, что у текущего пользователя есть требуемая роль(добавьте роль, если не хватает)

//Комп 2:
//{
//	AccessRequestsController

    //    POST /access-requests ----> Создать запрос на доступ к ресурсу(от текущего пользователя из JWT).
    //	GET /access-requests/me ----> Получить все запросы текущего пользователя.
    //    GET /access-requests/pending ----> Получить список всех нерассмотренных запросов(только для модераторов/админов).
    //	PATCH /access-requests/{id
    //}/ approve---- > Подтвердить запрос(только если у пользователя есть право утверждать).
    //    PATCH / access - requests /{ id}/ reject---- > Отклонить запрос(только модератор).
    //    GET / access - requests / resource /{ resourceId}/ active---- > Получить активные(утверждённые) запросы на конкретный ресурс.
    //}
    public class AllRequestsCommand : IRequest<IEnumerable<AccessRequestDTO>>
    {
        public Claim User { get; set; }

        public class AllRequestsCommandHandler : IRequestHandler<AllRequestsCommand, IEnumerable<AccessRequestDTO>>
        {
    
            private readonly ItCompany1135Context db;
            public AllRequestsCommandHandler(ItCompany1135Context db)
            {
                this.db = db;
            }


            public async Task<IEnumerable<AccessRequestDTO>> HandleAsync(AllRequestsCommand request, CancellationToken ct = default)
            {
                var claim = request.User;
                if (claim.Type != ClaimValueTypes.Sid)
                    return new List<AccessRequestDTO>();

                var client = db.Clients.Find(claim.Value);
                if (client == null)
                    return new List<AccessRequestDTO>();


                //GET / access - requests / me---- > Получить все запросы текущего пользователя.

                return db.AccessRequests.Where(s => s.UserSid == client.Sid).Select(s => new AccessRequestDTO
                {
                   UserS = s.UserS,
                   Status = s.Status,
                   ApprovedAt = s.ApprovedAt,
                   ApproverSid = s.ApproverSid,
                   CreatedAt = s.CreatedAt,
                   DeletedAt   = s.DeletedAt,
                   ModifiedAt = s.ModifiedAt,
                   RequestedAt = s.RequestedAt,
                   CreatedBy = s.CreatedBy,
                   DeletedBy = s.DeletedBy,
                   Id = s.Id,
                   IsDeleted = s.IsDeleted,
                   ModifiedBy = s.ModifiedBy,
                   RejectionReason = s.RejectionReason,
                   Resource = s.Resource,
                   ResourceId = s.ResourceId,
                   UserSid = s.UserSid,
                   
                }).ToList();

            }
        }
    }
}
