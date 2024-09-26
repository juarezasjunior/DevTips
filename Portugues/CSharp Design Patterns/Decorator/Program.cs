// Componente base
public interface INotificacao
{
    void EnviarMensagem(string mensagem);
}

// Componente concreto
public class NotificacaoEmail : INotificacao
{
    public void EnviarMensagem(string mensagem)
    {
        Console.WriteLine($"Enviando e-mail: {mensagem}");
    }
}

// Decorador base
public abstract class NotificacaoDecorator : INotificacao
{
    protected INotificacao _notificacao;

    public NotificacaoDecorator(INotificacao notificacao)
    {
        _notificacao = notificacao;
    }

    public virtual void EnviarMensagem(string mensagem)
    {
        _notificacao.EnviarMensagem(mensagem);
    }
}

// Decorador concreto para SMS
public class NotificacaoSMSDecorator : NotificacaoDecorator
{
    public NotificacaoSMSDecorator(INotificacao notificacao) : base(notificacao) { }

    public override void EnviarMensagem(string mensagem)
    {
        base.EnviarMensagem(mensagem);
        Console.WriteLine($"Enviando SMS: {mensagem}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Enviar notificação por e-mail
        INotificacao notificacaoEmail = new NotificacaoEmail();
        notificacaoEmail.EnviarMensagem("Olá!");

        // Enviar notificação por e-mail e SMS
        INotificacao notificacaoComSMS = new NotificacaoSMSDecorator(notificacaoEmail);
        notificacaoComSMS.EnviarMensagem("Olá!");
    }
}