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
      name: 'Relatórios',
      url: '/relatorio',
      icon: 'icon-speedometer'
    },
    {
      name: 'Ofertar Lanche',
      url: '/lanche',
      icon: 'icon-bell'
    },
    // {
    //   name: 'Login',
    //   url: '/pages/login',
    //   icon: 'icon-star'
    // },
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
