pipeline {

    agent any

    stages {
        stage('Build') {
            steps {
                docker image ls
            }
        }
        stage('Test') {
            steps {
                echo 'Testing...'
            }
        }
        stage('Deploy') {
            steps {
                echo 'Deploying....'
            }
        }
    }
}
