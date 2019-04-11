export default {
  items: [
    {
      name: 'Dashboard',
      url: '/dashboard',
      icon: 'icon-speedometer',
      badge: {
        variant: 'primary',
        text: 'NEW'
      }
    },
    {
      title: true,
      name: 'Components',
      class: '',
      wrapper: {
        element: '',
        attributes: {}
      }
    },
    {
      name: 'Notificações',
      url: '/notifications/modals',
      icon: 'icon-bell'
    },

    {
      name: 'Login',
      url: '/pages/login',
      icon: 'icon-star'
    },
    {
      name: 'Cadastro Aluno',
      url: '/base/formsAlunos',
      icon: 'icon-puzzle'
    },
    {
      name: 'Cadastro Estoque',
      url: '/base/formsEstoque',
      icon: 'icon-puzzle'
    }
  ]
}
