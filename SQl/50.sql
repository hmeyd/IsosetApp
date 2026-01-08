select *
from Users

delete from Users
where Email in ('john.doe@example.co', 'john.doe@example.com');