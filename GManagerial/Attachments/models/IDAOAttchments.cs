namespace GManagerial.Attachments
{
    internal interface IDAOAttchments
    {
        int Insert(IAttachment attachment);
       
        void Delete(IAttachment attachment);

    }
}
