pipeline {

    agent none

    stages {
        stage('Build') {
            agent { dockerfile true }
            steps {
                sh 'pwd'
            }
        }
        stage('Test') {
            agent { dockerfile true }
            steps {
                echo 'Testing...'
            }
        }
        stage('Deploy') {
            agent { dockerfile true }
            steps {
                echo 'Deploying....'
            }
        }
    }
}
